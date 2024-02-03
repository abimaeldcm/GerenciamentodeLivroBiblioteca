using GerenciamentodeLivroBiblioteca.Domain.Entites;

namespace GerenciamentodeLivroBiblioteca.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> AdicionarUsuario(Usuario usuarioAdcionar);
        Task<Usuario> EditarUsuario(Usuario usuarioEditar);
        Task<bool> DeleteUsuario(int id);
    }
}
