using System.Diagnostics.CodeAnalysis;
using JwtAuthentication.Core.Models;
using JwtAuthentication.Infrastructure.DbContexts.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.Infrastructure.DbContexts.Implementations
{
    /// <inheritdoc cref="IApplicationDbContext" />
    /// <inheritdoc cref="DbContext" />
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        /// <inheritdoc />
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <inheritdoc />
        public DbSet<User> Users { get; set; }
    }
}