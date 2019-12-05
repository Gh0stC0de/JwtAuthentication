using System;
using System.Linq;
using JwtAuthentication.Core.Models;
using JwtAuthentication.Infrastructure.DbContexts.Abstractions;
using JwtAuthentication.Service.Services.Abstractions;

namespace JwtAuthentication.Service.Services.Implementations
{
    /// <inheritdoc cref="IUserService" />
    public class UserService : IUserService, IDisposable
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserService"/> class with a context.
        /// </summary>
        /// <param name="context">Application database context</param>
        public UserService(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public User GetUser(string username)
        {
            return _context.Users.SingleOrDefault(u => u.IsEnabled && u.Username == username);
        }

        /// <inheritdoc />
        public User GetUser(Guid userId)
        {
            return _context.Users.SingleOrDefault(u => u.IsEnabled && u.Id == userId);
        }

        /// <inheritdoc />
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}