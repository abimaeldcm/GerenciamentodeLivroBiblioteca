namespace GerenciamentodeLivroBiblioteca.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> BuscarTodos();
        Task<T> BuscarPorId(int id);
        Task<T> Adicionar(T entity);
        Task<T> Editar(T entity);
        Task<bool> Deletar(int id);
    }
}
