using GuessWeight.Api.Entities;
using GuessWeight.Api.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GuessWeight.Api.Repositories
{
    public class TokenRepository: ITokenRepository
    {
        private readonly IConfiguration _configuration;
        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<object> GeneratorToken(Usuario usuario)
        {
            var Key = Encoding.ASCII.GetBytes(_configuration.GetSection("JWTConfiguracao")["secrets"]);
            var TokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("UsuarioId", usuario.Id.ToString()),
                    
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(TokenConfig);
            var tokenWrite = tokenHandler.WriteToken(token);
            return new
            {
                Token = tokenWrite
            };
        }
    }
}
