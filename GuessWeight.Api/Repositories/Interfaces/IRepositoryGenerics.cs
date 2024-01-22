namespace GuessWeight.Api.Repositories.Interfaces
{
    public interface IRepositoryGenerics<T>
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T Entity);
        Task<T> Delete(T Entity);
        Task<T> Update(T Entity);
    }
}
