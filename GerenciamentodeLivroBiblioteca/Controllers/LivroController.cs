using AutoMapper;
using GerenciamentodeLivroBiblioteca.Domain.DTOs;
using GerenciamentodeLivroBiblioteca.Domain.Entites;
using GerenciamentodeLivroBiblioteca.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GerenciamentodeLivroBiblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly IlivroServices _services;
        private readonly IMapper _mapper;

        public LivroController(IlivroServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }
        /// <summary>
        /// Buscar todos os livros
        /// </summary>
        /// <remarks>
        /// Buscar todos os livros cadastrados no banco de dados.
        /// </remarks>
        /// <response code="200">Livros carregados com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpGet("BuscarTodosLivros")]
        public async Task<ActionResult<List<LivroDTO.LivroBuscarDTO>>> BuscarTodosLivros()
        {
            var livroDB = await _services.BuscarTodosLivro();
            return _mapper.Map<List<LivroDTO.LivroBuscarDTO>>(livroDB);
        }
        /// <summary>
        /// Buscar livro por Id
        /// </summary>
        /// <remarks>
        /// Adicione um Id válido para buscar um livro.
        /// </remarks>
        /// <response code="200">Livro carregado com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpGet("BuscaPorId")]
        public async Task<ActionResult<LivroDTO.LivroBuscarDTO>> BuscaPorId(int id)
        {
            var livroDB = await _services.BuscarPorId(id);
            return _mapper.Map<LivroDTO.LivroBuscarDTO>(livroDB);
        }
        /// <summary>
        /// Adicionar livro
        /// </summary>
        /// <remarks>
        /// Adicione as informações para poder adicionar um novo livro no banco.
        /// </remarks>
        /// <response code="200">Livro adicionado com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpPost("Adicionar")]
        public async Task<ActionResult<LivroDTO.LivroBuscarDTO>> Adicionar([FromBody] LivroDTO.LivroCadastrarDTO livroAdicionar)
        {
            var novolivro = _mapper.Map<Livro>(livroAdicionar);
            var livroDB = await _services.AdicionarLivro(novolivro);
            return _mapper.Map<LivroDTO.LivroBuscarDTO>(livroDB);
        }
        /// <summary>
        /// Editar livro
        /// </summary>
        /// <remarks>
        /// Adicione as informações para poder editar um novo livro no banco.
        /// </remarks>
        /// <response code="200">Livro editado com sucesso</response>
        /// <response code="400">Erro de validação  </response>
        /// <response code="500">Erro no banco</response>
        [HttpPut("Editar")]
        public async Task<ActionResult<LivroDTO.LivroBuscarDTO>> Editar([FromBody] Livro livroEditar)
        {
            var livroDB = await _services.EditarLivro(livroEditar);
            return _mapper.Map<LivroDTO.LivroBuscarDTO>(livroDB);
        }
        [HttpDelete("Deletar")]
        public async Task<ActionResult<bool>> Deletar(int id)
        {
            return await _services.DeleteLivro(id);
        }
    }
}
