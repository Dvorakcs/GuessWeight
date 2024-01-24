using GuessWeight.Api.Entities;

namespace GuessWeight.Api.Repositories.Interfaces
{
    public interface IUsuarioRepository:IRepositoryGenerics<Usuario>
    {
       Task<Usuario> GetUsuarioPorEmailESenha(string EmailUsuario, string? SenhaUsuario = null);
    }
}
