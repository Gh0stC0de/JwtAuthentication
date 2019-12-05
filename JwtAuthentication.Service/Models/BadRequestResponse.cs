namespace JwtAuthentication.Service.Models
{
    /// <summary>
    ///     Represents a bad request response.
    /// </summary>
    public class BadRequestResponse
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BadRequestResponse" /> class.
        /// </summary>
        public BadRequestResponse()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BadRequestResponse" /> class with a title and a detail.
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="detail">The detail</param>
        public BadRequestResponse(string title, string detail)
        {
            Title = title;
            Detail = detail;
        }

        /// <summary>
        ///     Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Detail
        /// </summary>
        public string Detail { get; set; }
    }
}