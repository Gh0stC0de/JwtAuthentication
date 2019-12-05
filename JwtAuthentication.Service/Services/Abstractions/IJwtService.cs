namespace JwtAuthentication.Service.Services.Abstractions
{
    /// <summary>
    ///     Service for JSON web token.
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        ///     Gets a new JSON web token.
        /// </summary>
        /// <param name="userId">User identity</param>
        /// <returns>JSON web token as string</returns>
        string GetNewToken(string userId);
    }
}