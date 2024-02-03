using GerenciamentodeLivroBiblioteca.Domain.Entites;

namespace GerenciamentodeLivroBiblioteca.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<List<Livro>> LivrosPorNome(string nomeLivro);
        Task<List<Livro>> Emprestados();
        Task<List<Livro>> Disponiveis();
    }
}
