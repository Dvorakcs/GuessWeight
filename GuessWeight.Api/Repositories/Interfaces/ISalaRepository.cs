using GuessWeight.Api.Entities;
using GuessWeight.Library.Models;

namespace GuessWeight.Api.Repositories.Interfaces
{
    public interface ISalaRepository:IRepositoryGenerics<Sala>
    {
        Task<SalaDto> EntrarSala(Sala sala, Usuario usuario);
        Task<SalaDto> GetSalaEUsuarios(int id);    
    }
}
