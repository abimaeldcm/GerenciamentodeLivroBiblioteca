using GerenciamentodeLivroBiblioteca.Domain.Entites;

namespace GerenciamentodeLivroBiblioteca.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> UsuariosPorNome(string nome);
        Task<List<Usuario>> EmprestimosUsuario();
    }
}
