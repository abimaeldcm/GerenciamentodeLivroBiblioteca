using GerenciamentodeLivroBiblioteca.Domain.Entites;

namespace GerenciamentodeLivroBiblioteca.Infra.Data.Repository
{
    public interface IEmprestimoService
    {
        Task<List<Emprestimo>> BuscarTodos();
        Task<Emprestimo> BuscarPorId(int id);
        Task<List<Emprestimo>> BuscarPorLivro(int idLivro);
        Task<List<Emprestimo>> BuscarPorUsuario(int idUsuario);
        Task<List<Emprestimo>> BuscarPorData(DateTime dataInicio, DateTime dataFim);
        Task<Emprestimo> Adicionar(Emprestimo emprestimo);
        Task<Emprestimo> Editar(Emprestimo emprestimo);
        Task<Livro> DevolverLivro(int Id);
        Task<bool> Deletar(int id);
    }
}
