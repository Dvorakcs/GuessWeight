using GuessWeight.Api.Context;
using GuessWeight.Api.Entities;
using GuessWeight.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuessWeight.Api.Repositories
{
    public class UsuarioRepostaPesoRepository:IUsuarioRespostaPesoRepository
    {
        private readonly ConexaoDbContext _conexaoDbContext;

        public UsuarioRepostaPesoRepository(ConexaoDbContext conexaoDbContext)
        {
            _conexaoDbContext = conexaoDbContext;
        }

        public async Task<UsuarioRespostaPeso> Create(UsuarioRespostaPeso Entity)
        {
            await _conexaoDbContext.UsuarioRepostasPeso.AddAsync(Entity);
            await _conexaoDbContext.SaveChangesAsync();
            return Entity;
        }

        public async Task<UsuarioRespostaPeso> Delete(UsuarioRespostaPeso Entity)
        {
            _conexaoDbContext.UsuarioRepostasPeso.Remove(Entity);
            await _conexaoDbContext.SaveChangesAsync();
            return Entity;
        }

        public async Task<UsuarioRespostaPeso> Get(int id)
        {
            return await _conexaoDbContext.UsuarioRepostasPeso.Where(usuarioresp => usuarioresp.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UsuarioRespostaPeso>> GetAll()
        {
            return await _conexaoDbContext.UsuarioRepostasPeso.ToListAsync();
        }

        public async Task<UsuarioRespostaPeso> Update(UsuarioRespostaPeso Entity)
        {
            var usuarioresp =  _conexaoDbContext.UsuarioRepostasPeso.Update(Entity);
            await _conexaoDbContext.SaveChangesAsync();
            return usuarioresp.Entity;
        }
    }
}
