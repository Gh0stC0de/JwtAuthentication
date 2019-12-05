using System;

namespace JwtAuthentication.Service.Models
{
    /// <summary>
    ///     Represents an authentication response.
    /// </summary>
    public class AuthenticationResponse
    {
        /// <summary>
        ///     Identity
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        ///     Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     API token
        /// </summary>
        public string Token { get; set; }
    }
}