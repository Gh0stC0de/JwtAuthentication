using System.ComponentModel.DataAnnotations;

namespace JwtAuthentication.Service.Models
{
    /// <summary>
    ///     Represents a model for registration.
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        ///     Username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        ///     Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}