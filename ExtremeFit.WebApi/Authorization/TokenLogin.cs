using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using ExtremeFit.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ExtremeFit.WebApi.Authorization
{
    public class TokenLogin
    {
        public object GerarToken(UsuarioDomain usuario, SigningConfigurations signingConfigurations,
                                    TokenConfigurations tokenConfigurations)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(usuario.Id.ToString(), "Login"),
                new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Id.ToString()),
                    new Claim("Nome", usuario.Id.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email)
                }
            );

            foreach (var usuarioPermissao in usuario.Permissoes)
            {
                    identity.AddClaim(new Claim(ClaimTypes.Role, usuarioPermissao.Permissao.NomePermissao));
            }

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao.AddMonths(6);

            //gerar token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });

            var token = tokenHandler.WriteToken(securityToken);

            var retorno = new {
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };

            return retorno;
        }
    }
}