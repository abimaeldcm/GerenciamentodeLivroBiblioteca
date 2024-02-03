using GerenciamentodeLivroBiblioteca.Domain.Entites;

namespace GerenciamentodeLivroBiblioteca.Domain.Interfaces
{
    public interface IEmprestimoRepository
    {
        Task<List<Emprestimo>> BuscarPorUsuario(int idUsuario);
        Task<List<Emprestimo>> BuscarPorLivro(int idLivro);
        Task<List<Emprestimo>> BuscarPorData(DateTime dataInicio, DateTime dataFim);
        Task<Livro> DevolverLivro(int Id);
        
    }
}
