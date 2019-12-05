using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using JwtAuthentication.Core.Models;
using JwtAuthentication.Service.Exceptions;
using JwtAuthentication.Service.Models;
using JwtAuthentication.Service.Services.Abstractions;
using Mapster;

namespace JwtAuthentication.Service.Services.Implementations
{
    /// <inheritdoc />
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthenticationService" /> class with a user service and a JSON web
        ///     token service.
        /// </summary>
        /// <param name="userService">User service</param>
        /// <param name="jwtService">JSON web token service</param>
        public AuthenticationService(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        /// <inheritdoc />
        public AuthenticationResponse Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new InvalidCredentialsException("Username or password can not be empty.");

            var user = _userService.GetUser(username);

            if (user == null) throw new InvalidCredentialsException("Invalid username or password.");

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new InvalidCredentialsException("Invalid username or password.");

            var response = user.Adapt<AuthenticationResponse>();
            response.Token = _jwtService.GetNewToken(user.Id.ToString());

            return response;
        }

        /// <inheritdoc />
        public User Register(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("Value can not be null, empty or whitespace.", nameof(user.Username));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value can not be null, empty or whitespace.", nameof(password));

            var doesUserExist = _userService.GetUser(user.Username) != null;
            if (doesUserExist) throw new InvalidOperationException($"The username '{user.Username}' is already taken.");

            var (hash, salt) = CreateHashAndSalt(password);
            user.PasswordHash = hash;
            user.PasswordSalt = salt;

            _userService.Add(user);
            return user;
        }

        /// <summary>
        ///     Creates a has and salt of a password.
        /// </summary>
        /// <param name="password">The password</param>
        /// <returns>Hash and salt</returns>
        /// <exception cref="ArgumentException">An argument is invalid.</exception>
        /// <exception cref="ArgumentNullException">An argument is null.</exception>
        private static (byte[] hash, byte[] salt) CreateHashAndSalt(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value can not be null, empty or whitespace.", nameof(password));

            using var hmac = new HMACSHA512();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return (hash, salt);
        }

        /// <summary>
        ///     Verifies a password hash.
        /// </summary>
        /// <param name="password">The password</param>
        /// <param name="passwordHash">The password hash</param>
        /// <param name="passwordSalt">The password salt</param>
        /// <returns><c>True</c> if the hash oft the <paramref name="password"></paramref> equals the <paramref name="passwordHash"/>.</returns>
        /// <exception cref="ArgumentNullException">An argument is null.</exception>
        /// <exception cref="ArgumentException">An argument is invalid.</exception>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value can not be null, empty or whitespace.", nameof(password));
            if (passwordHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (expected 64)", nameof(passwordHash));
            if (passwordSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (expected 128)", nameof(passwordSalt));

            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return !computedHash.Where((t, i) => t != passwordHash[i]).Any();
        }
    }
}