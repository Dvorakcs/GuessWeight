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
        public async Task<Game> Create(Game Entity)
        {
            await _conexaoDbContext.Games.AddAsync(Entity);
            await _conexaoDbContext.SaveChangesAsync();
            return Entity;
        }

        public async Task<Game> Delete(Game Entity)
        {
            _conexaoDbContext.Games.Remove(Entity);
            await _conexaoDbContext.SaveChangesAsync();
            return Entity;
        }

        public async Task<Game> Get(int id)
        {
            return await _conexaoDbContext.Games.Where(game => game.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _conexaoDbContext.Games.ToListAsync();
        }

        public async Task<Game> Update(Game Entity)
        {
            var usuarioresp = _conexaoDbContext.Games.Update(Entity);
            await _conexaoDbContext.SaveChangesAsync();
            return usuarioresp.Entity;
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
            if(game.Finaliza is false)
            {
                var respostas = await _conexaoDbContext.UsuarioRepostasPeso.Where(resposta => resposta.GameId == game.Id).ToListAsync();
                bool todosResponderam = true;
                if (respostas.Count() > 0)
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

            }

            return game;
        }
    }
}
