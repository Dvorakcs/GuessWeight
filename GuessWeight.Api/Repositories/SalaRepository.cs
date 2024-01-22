using GuessWeight.Api.Context;
using GuessWeight.Api.Entities;
using GuessWeight.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuessWeight.Api.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        private readonly ConexaoDbContext _conexaoDbContext;

        public SalaRepository(ConexaoDbContext conexaoDbContext)
        {
            _conexaoDbContext = conexaoDbContext;
        }

        public async Task<Sala> Create(Sala Entity)
        {
           await _conexaoDbContext.Salas.AddAsync(Entity);
           await _conexaoDbContext.SaveChangesAsync();
           return Entity;
        }

        public async Task<Sala> Delete(Sala Entity)
        {
            throw new NotImplementedException();
        }

        public async Task EntrarSala(Sala sala, Usuario usuario)
        {
            usuario.Id = sala.Id;
            _conexaoDbContext.Salas.Update(sala);
            await _conexaoDbContext.SaveChangesAsync();
        }

        public async Task<Sala> Get(int id)
        {
            return await _conexaoDbContext.Salas.Where(sala => sala.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Sala>> GetAll()
        {
            return await _conexaoDbContext.Salas.ToListAsync();
        }

        public async Task<Sala> Update(Sala Entity)
        {
            throw new NotImplementedException();
        }
    }
}
