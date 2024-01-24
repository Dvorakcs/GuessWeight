using GuessWeight.Api.Entities;

namespace GuessWeight.Api.Repositories.Interfaces
{
    public interface IGameRepository:IRepositoryGenerics<Game>
    {
        Task<Game> CreateGame(Sala sala);
        Task<Game> Vencedor(int gameId);
    }
}
