using GerenciamentodeLivroBiblioteca.Domain.Entites;
using GerenciamentodeLivroBiblioteca.Domain.Interfaces;

namespace GerenciamentodeLivroBiblioteca.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario> _usuariosRepository;

        public UsuarioService(IRepository<Usuario> usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }
        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _usuariosRepository.BuscarTodos();
        }
        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _usuariosRepository.BuscarPorId(id);
        }
        public async Task<Usuario> AdicionarUsuario(Usuario usuarioAdcionar)
        {
            return await _usuariosRepository.Adicionar(usuarioAdcionar);
        }
        public async Task<Usuario> EditarUsuario(Usuario usuarioEditar)
        {
            return await _usuariosRepository.Editar(usuarioEditar);
        }
        public async Task<bool> DeleteUsuario(int id)
        {
            return await _usuariosRepository.Deletar(id);
        }


    }
}
