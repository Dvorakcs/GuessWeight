using GuessWeight.Api.Context;
using GuessWeight.Api.Entities;
using GuessWeight.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuessWeight.Api.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ConexaoDbContext _conexaoDbContext;

        public GameRepository(ConexaoDbContext conexaoDbContext)
        {
            _conexaoDbContext = conexaoDbContext;
        }
        public Task<Game> Create(Game Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Game> Delete(Game Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Game> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Game>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Game> Update(Game Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Game> CreateGame(Sala sala)
        {
            List<Usuario> usuario = await _conexaoDbContext.Usuarios.Where(usuario => usuario.SalaId == sala.Id).ToListAsync();

            var game = new Game
            {
                Name = "TesteGame",
                SalaId = sala.Id,
                StartGame = true
            };

            await _conexaoDbContext.Games.AddAsync(game);
            await _conexaoDbContext.SaveChangesAsync();

            foreach (var item in usuario)
            {
                await _conexaoDbContext.UsuarioRepostasPeso.AddAsync(new UsuarioRespostaPeso
                {
                    GameId = game.Id,
                    UsuarioId = item.Id,
                });
            }
            await _conexaoDbContext.SaveChangesAsync();
            return game;
        }

        public async Task<Game> Vencedor(int gameId)
        {
            var game = await _conexaoDbContext.Games.Where(game => game.Id == gameId).FirstOrDefaultAsync();
            var respostas = await _conexaoDbContext.UsuarioRepostasPeso.Where(resposta => resposta.GameId == game.Id).ToListAsync();
            bool todosResponderam = true;
            if (respostas is not null)
            {
                foreach (var item in respostas)
                {
                    if (item.EnviouResposta == false)
                    {
                        todosResponderam = false;
                    }
                }

                if (todosResponderam is true)
                {
                    var usuarioWin = respostas.OrderBy(resposta => Math.Abs(resposta.Resposta - game.ObjetoPeso)).First();

                    game.UsuarioWinId = usuarioWin.Id;
                    game.Finaliza = true;
                    _conexaoDbContext.Games.Update(game);
                    await _conexaoDbContext.SaveChangesAsync();
                    return game;
                };

            }

            return game;
        }
    }
}
