using GuessWeight.Api.Entities;

namespace GuessWeight.Api.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        Task<object> GeneratorToken(Usuario usuario);
    }
}
