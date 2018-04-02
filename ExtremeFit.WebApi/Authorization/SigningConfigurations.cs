using Microsoft.IdentityModel.Tokens;

namespace ExtremeFit.WebApi.Authorization
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }
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