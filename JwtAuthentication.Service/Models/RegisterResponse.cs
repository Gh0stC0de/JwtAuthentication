using System;

namespace JwtAuthentication.Service.Models
{
    /// <summary>
    ///     Represents a register response.
    /// </summary>
    public class RegisterResponse
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterResponse"/> class.
        /// </summary>
        public RegisterResponse()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterResponse"/> class with a user identity and a username.
        /// </summary>
        /// <param name="userId">The user identity</param>
        /// <param name="username">The username</param>
        public RegisterResponse(Guid userId, string username)
        {
            UserId = userId;
            Username = username;
        }

        /// <summary>
        ///     User identity
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        ///     Username
        /// </summary>
        public string Username { get; set; }
    }
}