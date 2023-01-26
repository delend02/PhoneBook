using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace PhoneBook.Application
{
    public class Manager
    {
        private SecurityKey SecurityKey { get; }
        private SigningCredentials SigningCredentials { get; }
        private JwtSecurityTokenHandler TokenHandler { get; }
        private TokenValidationParameters TokenValidationParameters { get; }

        public Manager(string rsaPrivateKey)
        {
            var privateKeyBuffer = new Span<byte>(new byte[rsaPrivateKey.Length]);
            Convert.TryFromBase64String(rsaPrivateKey, privateKeyBuffer, out _);

            var rsa = RSA.Create();
            rsa.ImportPkcs8PrivateKey(privateKeyBuffer, out var _);

            SecurityKey = new RsaSecurityKey(rsa);

            SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.RsaSha256);

            TokenValidationParameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
                RequireSignedTokens = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = SecurityKey
            };

            TokenHandler = new JwtSecurityTokenHandler();
        }

        public string CreateToken(Dictionary<string, object> claims = null, DateTime? expired = null)
        {
            var jwtSecurityToken = TokenHandler.CreateJwtSecurityToken(
                new SecurityTokenDescriptor
                {
                    Claims = claims,
                    Expires = expired ?? DateTime.Now.AddHours(1),
                    SigningCredentials = SigningCredentials
                });

            return TokenHandler.WriteToken(jwtSecurityToken);
        }

        public bool ValidateToken(string token, out JwtSecurityToken jwtToken)
        {
            jwtToken = null;

            try
            {
                TokenHandler.ValidateToken(token, TokenValidationParameters, out var validatedToken);

                jwtToken = validatedToken as JwtSecurityToken;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
