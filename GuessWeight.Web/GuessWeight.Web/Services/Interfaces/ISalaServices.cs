using GuessWeight.Library.Models;

namespace GuessWeight.Web.Services.Interfaces
{
    public interface ISalaServices
    {
        Task<IEnumerable<SalaDto>> getSalaAll();
        Task<SalaDto> EntrarSala(UsuarioEntraSalaDto usuarioEntraSalaDto);
        Task<SalaDto> getSala(int Id);
    }
}
