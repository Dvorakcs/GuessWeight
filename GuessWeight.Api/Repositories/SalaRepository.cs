using GuessWeight.Api.Context;
using GuessWeight.Api.Entities;
using GuessWeight.Api.Repositories.Interfaces;
using GuessWeight.Library.Models;
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
            _conexaoDbContext.Salas.Remove(Entity);
            await _conexaoDbContext.SaveChangesAsync();
            return Entity;
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
            var usuarioresp = _conexaoDbContext.Salas.Update(Entity);
            await _conexaoDbContext.SaveChangesAsync();
            return usuarioresp.Entity;
        }

        public async Task<SalaDto> EntrarSala(Sala sala, Usuario usuario)
        {
            usuario.SalaId = sala.Id;
            _conexaoDbContext.Usuarios.Update(usuario);
            await _conexaoDbContext.SaveChangesAsync();
            return new SalaDto
            {
                Id = sala.Id,
                Nome = sala.Nome,
                QuantidadePartida = sala.QuantidadePartida,
                QuantidadeTempo = sala.QuantidadeTempo,

            };
        }

        public async Task<SalaDto> GetSalaEUsuarios(int id)
        {
            List<UsuarioDto> usuario = await _conexaoDbContext.Usuarios.Where(usuario => usuario.SalaId == id)
                .Select(usuario => new UsuarioDto
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                }).ToListAsync();


            return await _conexaoDbContext.Salas.Select(salaDto => new SalaDto
            {
                Id = salaDto.Id,
                Nome = salaDto.Nome,
                Usuarios = usuario

            }).FirstOrDefaultAsync();

        }
    }
}
