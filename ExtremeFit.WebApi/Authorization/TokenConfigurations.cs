namespace ExtremeFit.WebApi.Authorization
{
    /// <summary>
    /// Objeto para criação do token de login
    /// </summary>
    public class TokenConfigurations
    {
        /// <summary>
        /// TokenAudience
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// TokenIssuer
        /// </summary>
        public string Issuer { get; set; }
    }
}