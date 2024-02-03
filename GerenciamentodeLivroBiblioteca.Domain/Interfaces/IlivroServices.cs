using GerenciamentodeLivroBiblioteca.Domain.Entites;

namespace GerenciamentodeLivroBiblioteca.Domain.Interfaces
{
    public interface IlivroServices
    {
        Task<List<Livro>> BuscarTodosLivro();
        Task<Livro> BuscarPorId(int id);
        Task<Livro> AdicionarLivro(Livro livroAdcionar);
        Task<Livro> EditarLivro(Livro livroEditar);
        Task<bool> DeleteLivro(int id);
    }
}
