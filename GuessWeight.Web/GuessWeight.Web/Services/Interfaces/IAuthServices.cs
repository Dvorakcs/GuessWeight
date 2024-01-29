using GuessWeight.Library.Models;

namespace GuessWeight.Web.Services.Interfaces
{
    public interface IAuthServices
    {
        Task<LoginRetornoUsuarioDto> Login(LoginUsuarioDto loginUsuarioDto);
        Task<LoginRetornoUsuarioDto> Create(UsuarioDto usuarioDto);
    }
}
