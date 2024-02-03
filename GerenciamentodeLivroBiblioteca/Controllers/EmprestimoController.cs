using AutoMapper;
using GerenciamentodeLivroBiblioteca.Domain.DTOs;
using GerenciamentodeLivroBiblioteca.Domain.Entites;
using GerenciamentodeLivroBiblioteca.Infra.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentodeLivroBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoService _service;
        private readonly IMapper _mapper;

        public EmprestimoController(IEmprestimoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        /// <summary>
        /// Buscar todos os Empréstimos
        /// </summary>
        /// <remarks>
        /// Busca todos as empréstimos cadastrados no Banco de Dados
        /// </remarks>
        /// <response code="200">empréstimos carregados com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpGet("BuscarTodos")]
        public async Task<ActionResult<List<EmprestimoDTO.EmprestimoBuscarDTO>>> BuscarTodos()
        {
            var emprestimosDB = await _service.BuscarTodos();
            var emprestimosDBDTO = _mapper.Map<List<EmprestimoDTO.EmprestimoBuscarDTO>>(emprestimosDB);

            return emprestimosDBDTO;
        }
        /// <summary>
        /// Buscar por Id do livro
        /// </summary>
        /// <remarks>
        /// Adicione o Id de um livro para ver o histórico de empréstimos dele.
        /// </remarks>
        /// <response code="200">Empréstimos carregados com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpGet("BuscarPorLivro")]
        public async Task<ActionResult<List<EmprestimoDTO.EmprestimoBuscarDTO>>> BuscarPorLivro(int idLivro)
        {
            var emprestimosDB = await _service.BuscarPorLivro(idLivro);
            var emprestimosDBDTO = _mapper.Map<List<EmprestimoDTO.EmprestimoBuscarDTO>>(emprestimosDB);
            return emprestimosDBDTO;
        }
        /// <summary>
        /// Buscar por Id do usuário
        /// </summary>
        /// <remarks>
        /// Adicione o Id de um usuário para ver o histórico de Empréstimos dele.
        /// </remarks>
        /// <response code="200">Empréstimos carregados com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpGet("BuscarPorUsuario")]
        public async Task<ActionResult<List<EmprestimoDTO.EmprestimoBuscarDTO>>> BuscarPorUsuario(int Id)
        {
            var emprestimosDB = await _service.BuscarPorUsuario(Id);
            var emprestimosDBDTO = _mapper.Map<List<EmprestimoDTO.EmprestimoBuscarDTO>>(emprestimosDB);
            return emprestimosDBDTO;
        }
        /// <summary>
        /// Buscar por Id do emprestimo
        /// </summary>
        /// <remarks>
        /// Adicione o Id de um emprestimo para saber mais detalhes.
        /// </remarks>
        /// <response code="200">Empréstimos carregados com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpGet("BuscarPorId")]
        public async Task<ActionResult<EmprestimoDTO.EmprestimoBuscarDTO>> BuscarPorId(int id)
        {
            var emprestimosDB = await _service.BuscarPorId(id);
            var emprestimosDBDTO = _mapper.Map<EmprestimoDTO.EmprestimoBuscarDTO>(emprestimosDB);
            return emprestimosDBDTO;
        }
        /// <summary>
        /// Buscar Empréstimos por período
        /// </summary>
        /// <remarks>
        /// Adicione uma data de inicio e fim para poder realizar uma busca de Empréstimos neste período. 
        /// Exemplo:
        ///     dataInicio: 2024-02-02T00:00:00
        ///     dataFim: 2024-02-02T23:59:59
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Empréstimos adicionada com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpGet("BuscarPorData")]
        public async Task<ActionResult<List<EmprestimoDTO.EmprestimoBuscarDTO>>> BuscarPorData(DateTime dataInicio, DateTime dataFim)
        {
            var emprestimosDB = await _service.BuscarPorData(dataInicio, dataFim);
            var emprestimosDBDTO = _mapper.Map<List<EmprestimoDTO.EmprestimoBuscarDTO>>(emprestimosDB);
            return emprestimosDBDTO;
        }
        /// <summary>
        /// Adicionar emprestimo
        /// </summary>
        /// <remarks>
        /// Adicione as informações do emprestimo que deseja criar
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">emprestimo adicionado com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpPost("Adicionar")]
        public async Task<ActionResult<EmprestimoDTO.EmprestimoBuscarDTO>> Adicionar(EmprestimoDTO.EmprestimoCadastrarDTO emprestimoDTO)
        {
            var emprestimoAdd = _mapper.Map<Emprestimo>(emprestimoDTO);
            var a = _mapper.Map<EmprestimoDTO.EmprestimoBuscarDTO>(await _service.Adicionar(emprestimoAdd));
            return a;
        }
        /// <summary>
        /// Editar emprestimo
        /// </summary>
        /// <remarks>
        ///  Adicione as informações do emprestimo que deseja editar
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">emprestimo editado com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpPut("Editar")]
        public async Task<ActionResult<EmprestimoDTO.EmprestimoBuscarDTO>> Editar(EmprestimoDTO.EmprestimoBuscarDTO emprestimoDTO)
        {
            var emprestimoEditar = _mapper.Map<Emprestimo>(emprestimoDTO);
            return _mapper.Map<EmprestimoDTO.EmprestimoBuscarDTO>(await _service.Editar(emprestimoEditar));
        }
        /// <summary>
        /// Devolver um livro
        /// </summary>
        /// <remarks>
        ///  Informe o Id do livroque deseja devolver.
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">livro devolvido com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpPut("DevolverLivro")]
        public async Task<ActionResult<Livro>> DevolverLivro(int Id)
        {
            return await _service.DevolverLivro(Id);
        }
        /// <summary>
        /// Deletar emprestimo
        /// </summary>
        /// <remarks>
        ///  Adicione o Id do emprestimo que deseja excluido do banco de dados
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">emprestimo deletado com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpDelete("Deletar")]
        public async Task<ActionResult<bool>> Deletar(int id)
        {
            return await _service.Deletar(id);

        }
    }
}
