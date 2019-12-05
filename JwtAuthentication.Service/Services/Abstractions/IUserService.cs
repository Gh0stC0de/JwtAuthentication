using System;
using JwtAuthentication.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.Service.Services.Abstractions
{
    /// <summary>
    ///     Represents a service to interact with a user.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///     Gets a user by the username.
        /// </summary>
        /// <remarks>Only enabled users will be checked.</remarks>
        /// <param name="username">The username.</param>
        /// <returns>The user</returns>
        /// <exception cref="ArgumentNullException">The argument <paramref name="username" />is null.</exception>
        /// <exception cref="InvalidOperationException">There is more then one user with the given username.</exception>
        User GetUser(string username);

        /// <summary>
        ///     Gets a user by the identity.
        /// </summary>
        /// <remarks>Only enabled users will be checked.</remarks>
        /// <param name="userId">The user identity.</param>
        /// <returns>The user</returns>
        /// <exception cref="InvalidOperationException">There is more then one user with the given username.</exception>
        User GetUser(Guid userId);

        /// <summary>
        ///     Adds a user.
        /// </summary>
        /// <param name="user">The user to add</param>
        /// <exception cref="DbUpdateException">
        ///     An error is encountered while saving to the database.
        /// </exception>
        /// <exception cref="DbUpdateConcurrencyException">
        ///     A concurrency violation is encountered while saving to the database.
        /// </exception>
        /// >
        void Add(User user);
    }
}