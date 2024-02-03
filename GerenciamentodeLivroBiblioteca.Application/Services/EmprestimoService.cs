using GerenciamentodeLivroBiblioteca.Domain.Entites;
using GerenciamentodeLivroBiblioteca.Domain.Interfaces;
using GerenciamentodeLivroBiblioteca.Infra.Data.Repository;

namespace GerenciamentodeLivroBiblioteca.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IRepository<Emprestimo> _repository;
        private readonly IRepository<Livro> _livrorepository;
        private readonly IRepository<Usuario> _usuariorepository;
        private readonly IEmprestimoRepository _emprestimosRepository;

        public EmprestimoService(IRepository<Emprestimo> repository, IRepository<Livro> livrorepository, IRepository<Usuario> usuariorepository, IEmprestimoRepository emprestimosRepository)
        {
            _repository = repository;
            _livrorepository = livrorepository;
            _usuariorepository = usuariorepository;
            _emprestimosRepository = emprestimosRepository;
        }

        public async Task<List<Emprestimo>> BuscarTodos()
        {
            var emprestimosDB = await _repository.BuscarTodos();
            //não retornar erro
            return emprestimosDB.Any() ? emprestimosDB : throw new Exception("Banco vázio");
        }
        public async Task<List<Emprestimo>> BuscarPorLivro(int idLivro)
        {
            var emprestimosDB = await _emprestimosRepository.BuscarPorLivro(idLivro);
            return emprestimosDB.Any() ? emprestimosDB : throw new Exception("Não localizado");
        }
        public async Task<Emprestimo> BuscarPorId(int id)
        {
            var emprestimoDB = await _repository.BuscarPorId(id);
            return emprestimoDB != null ? emprestimoDB : throw new Exception("Emprestimo não localizado");
        }
        public async Task<List<Emprestimo>> BuscarPorData(DateTime dataInicio, DateTime dataFim)
        {
            var emprestimosDB = await _emprestimosRepository.BuscarPorData(dataInicio, dataFim);
            return emprestimosDB.Any() ? emprestimosDB : throw new Exception("Não foi localizado nenhum emprestimo nesse período");
        }
        public async Task<List<Emprestimo>> BuscarPorUsuario(int idUsuario)
        {
            //não retornar erro
            var emprestimosDB = await _emprestimosRepository.BuscarPorUsuario(idUsuario);
            return emprestimosDB.Any() ? emprestimosDB : throw new Exception("Não foi localizado emprestimos do usuário informado");
        }
        public async Task<Emprestimo> Adicionar(Emprestimo emprestimo)
        {
            try
            {
                var livroDB = await _livrorepository.BuscarPorId(emprestimo.IdLivro);

                if (livroDB is null)
                {
                    throw new Exception("Livro não encontrado");
                }
                else if (livroDB.Disponivel is false)
                {
                    throw new Exception("Livro não está disponível");

                }
                var usuarioDB = await _usuariorepository.BuscarPorId(emprestimo.IdUsuario);
                if (usuarioDB is null)
                {
                    throw new Exception("Usuario não encontrado");
                }

                livroDB.Disponivel = false;
                await _livrorepository.Editar(livroDB);
                return await _repository.Adicionar(emprestimo);
            }
            catch (Exception mensagem)
            {
                throw new Exception($"Erro ao validar os dados: {mensagem.Message}");
            }
        }
        public async Task<Emprestimo> Editar(Emprestimo emprestimo)
        {
            try
            {
                return await _repository.Editar(emprestimo);
            }
            catch (Exception mensagem)
            {

                throw new Exception($"Erro ao realizar a edição do emprestimo: {mensagem.Message}");
            }

        }
        public async Task<Livro> DevolverLivro(int Id)
        {
            try
            {
                return await _emprestimosRepository.DevolverLivro(Id);
            }
            catch (Exception mensagem)
            {
                throw new Exception($"Erro ao realizar a devolução do livro: {mensagem.Message}");
            }
        }
        public async Task<bool> Deletar(int id)
        {
            try
            {
                return await _repository.Deletar(id);
            }
            catch (Exception mensagem)
            {
                throw new Exception($"Erro ao realizar a deleção do emprestimo: {mensagem.Message}");
            }
        }

    }
}
