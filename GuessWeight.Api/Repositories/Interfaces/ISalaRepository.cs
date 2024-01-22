using GuessWeight.Api.Entities;

namespace GuessWeight.Api.Repositories.Interfaces
{
    public interface ISalaRepository:IRepositoryGenerics<Sala>
    {
        Task EntrarSala(Sala sala, Usuario usuario);
    }
}
