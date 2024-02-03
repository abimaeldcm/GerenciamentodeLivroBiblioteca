using GerenciamentodeLivroBiblioteca.Domain.Entites;
using GerenciamentodeLivroBiblioteca.Domain.Interfaces;

namespace GerenciamentodeLivroBiblioteca.Application.Services
{
    public class LivroServices : IlivroServices
    {
        private readonly IRepository<Livro> _repository;

        public LivroServices(IRepository<Livro> repository)
        {
            _repository = repository;
        }

        public async Task<List<Livro>> BuscarTodosLivro()
        {
            return await _repository.BuscarTodos();
        }
        public async Task<Livro> BuscarPorId(int id)
        {
            var livroId = await _repository.BuscarPorId(id);
            return livroId is null ? throw new Exception("Livro não localizado") : livroId;
        }

        public async Task<Livro> AdicionarLivro(Livro livroAdcionar)
        {
            return await _repository.Adicionar(livroAdcionar);
        }
        public Task<Livro> EditarLivro(Livro livroEditar)
        {
            return _repository.Editar(livroEditar);
        }
        public Task<bool> DeleteLivro(int id)
        {
            return _repository.Deletar(id);
        }
    }
}
