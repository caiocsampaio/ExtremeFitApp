using Microsoft.IdentityModel.Tokens;

namespace ExtremeFit.WebApi.Authorization
{
    /// <summary>
    /// Configurações de token
    /// </summary>
    public class SigningConfigurations
    {
        /// <summary>
        /// TokenKey
        /// </summary>
        public SecurityKey Key { get; }

        /// <summary>
        /// TokenCredentials
        /// </summary>
        public SigningCredentials SigningCredentials { get; }

        /// <summary>
        /// Configurações de token
        /// </summary>
        public SigningConfigurations()
        {
            using (var provider = new System.Security.Cryptography.RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}