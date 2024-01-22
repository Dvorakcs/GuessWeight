using GuessWeight.Api.Context;
using GuessWeight.Api.Entities;
using GuessWeight.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuessWeight.Api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConexaoDbContext _conexaoDbContext;

        public UsuarioRepository(ConexaoDbContext conexaoDbContext)
        {
            _conexaoDbContext = conexaoDbContext;
        }

        public async Task<Usuario> Create(Usuario Entity)
        {
            await _conexaoDbContext.Usuarios.AddAsync(Entity);
            await _conexaoDbContext.SaveChangesAsync();
            return Entity;
        }

        public async Task<Usuario> Delete(Usuario Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Get(int id)
        {
            return await _conexaoDbContext.Usuarios.Where(usuario => usuario.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetUsuarioPorEmailESenha(string EmailUsuario, string? SenhaUsuario)
        {
            if (SenhaUsuario is not null)
            {
                return await _conexaoDbContext.Usuarios.Where(usuario => usuario.Email == EmailUsuario && 
                                                              usuario.Senha == SenhaUsuario).FirstOrDefaultAsync();
            }
            return await _conexaoDbContext.Usuarios.Where(usuario => usuario.Email == EmailUsuario).FirstOrDefaultAsync();
        }

        public async Task<Usuario> Login(string EmailUsuario, string SenhaUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Update(Usuario Entity)
        {
            throw new NotImplementedException();
        }
    }
}
