using GerenciamentodeLivroBiblioteca.Domain.Entites;
using GerenciamentodeLivroBiblioteca.Domain.Interfaces;
using GerenciamentodeLivroBiblioteca.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentodeLivroBiblioteca.Infra.Data.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly ApplicationDataBase _DbContext;

        public EmprestimoRepository(ApplicationDataBase dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<List<Emprestimo>> BuscarPorUsuario(int idUsuario)
        {
            return await _DbContext.Emprestimos.Where(x => x.IdUsuario == idUsuario).ToListAsync();
        }
        public async Task<List<Emprestimo>> BuscarPorLivro(int idLivro)
        {
            return await _DbContext.Emprestimos.Where(x => x.IdLivro == idLivro).ToListAsync();
        }
        public async Task<List<Emprestimo>> BuscarPorData(DateTime dataInicio, DateTime dataFim)
        {
            return await _DbContext.Emprestimos.Where(x => x.DataEmprestimo >= dataInicio && x.DataEmprestimo <= dataFim).ToListAsync();
        }
        public async Task<Livro> DevolverLivro(int Id)
        {
            var livro = await _DbContext.Livros.FirstOrDefaultAsync(x => x.Id == Id);
            if (livro is not null)
            {
                livro.Disponivel = true;

                _DbContext.Update(livro);
                await _DbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Livro não localizado.");
            }

            return livro;
        }
    }
}
