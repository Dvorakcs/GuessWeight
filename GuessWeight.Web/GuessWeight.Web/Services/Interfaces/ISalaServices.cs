using GuessWeight.Library.Models;

namespace GuessWeight.Web.Services.Interfaces
{
    public interface ISalaServices
    {
        Task<IEnumerable<SalaDto>> getSalaAll();
        Task<SalaDto> EntrarSala(UsuarioEntraSalaDto usuarioEntraSalaDto);
        Task<SalaDto> getSala(int Id);
        Task<GameDto> StartGame(int SalaId);
        Task<GameDto> GetGame(int Id);
        Task EnviaResposta(UsuarioRespostaPesoDto usuarioRespostaPesoDto);
        Task FinalizaGame(int Id);
        Task<UsuarioDto> GetUsuario(int Id);
    }
}
