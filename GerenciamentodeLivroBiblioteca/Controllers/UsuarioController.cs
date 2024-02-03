using GerenciamentodeLivroBiblioteca.Domain.Entites;
using GerenciamentodeLivroBiblioteca.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentodeLivroBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Buscar todos os usuários
        /// </summary>
        /// <remarks>
        /// Buscar todos os usuários cadastrados no banco de dados.
        /// </remarks>
        /// <response code="200">Usuários carregados com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpGet("BuscaTodos")]
        public async Task<ActionResult<List<Usuario>>> BuscaTodos()
        {
            return await _usuarioService.BuscarTodosUsuarios();
        }
        /// <summary>
        /// Buscar usuário Por Id
        /// </summary>
        /// <remarks>
        /// Adicione um Id válido para localizar um usuário no banco de dados.
        /// </remarks>
        /// <response code="200">Usuário localizado com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpGet("BuscaPorId")]
        public async Task<ActionResult<Usuario>> BuscaPorId(int id)
        {
            return await _usuarioService.BuscarPorId(id);
        }
        /// <summary>
        /// Adicionar um novo usuário
        /// </summary>
        /// <remarks>
        /// Adicione as informações para adicionar um usuário ao banco de dados.
        /// </remarks>
        /// <response code="200">Usuários adicionado com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpPost("Adicionar")]
        public async Task<ActionResult<Usuario>> Adicionar([FromBody] Usuario usuarioAdicionar)
        {
            return await _usuarioService.AdicionarUsuario(usuarioAdicionar);
        }
        /// <summary>
        /// Editar um usuário
        /// </summary>
        /// <remarks>
        /// Adicione as informações para editar um usuário no banco de dados.
        /// </remarks>
        /// <response code="200">Usuário editado com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpPut("Editar")]
        public async Task<ActionResult<Usuario>> Editar([FromBody] Usuario usuarioEditar)
        {
            return await _usuarioService.EditarUsuario(usuarioEditar);
        }
        /// <summary>
        /// Deletar um usuário
        /// </summary>
        /// <remarks>
        /// Adicione um Id válido para deletar um usuário do banco de dados.
        /// </remarks>
        /// <response code="200">Usuário deletado com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpDelete("Deletar")]
        public async Task<ActionResult<bool>> Deletar(int id)
        {
            return await _usuarioService.DeleteUsuario(id);
        }
    }
}
