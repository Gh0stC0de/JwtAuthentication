namespace JwtAuthentication.Service.Helpers
{
    /// <summary>
    ///     Represents application settings
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        ///     Secret to sign json web tokens
        /// </summary>
        public string TokenSecret { get; set; }

        /// <summary>
        ///     Token expiration in days
        /// </summary>
        public int TokenExpirationInDays { get; set; }
    }
}