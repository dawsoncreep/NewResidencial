namespace ServicesClient.Models
{
    /// <summary>
    /// The login request.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }
}