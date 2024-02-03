using GerenciamentodeLivroBiblioteca.Domain.Interfaces;
using GerenciamentodeLivroBiblioteca.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentodeLivroBiblioteca.Infra.Data.Repository
{
    public class EntityRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDataBase _dbContext;

        public EntityRepository(ApplicationDataBase dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<T>> BuscarTodos()
        {
            return _dbContext.Set<T>().ToListAsync();
        }
        public async Task<T> BuscarPorId(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> Adicionar(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task<T> Editar(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task<bool> Deletar(int id)
        {
            try
            {
                var entityToDelete = await BuscarPorId(id);

                if (entityToDelete != null)
                {
                    _dbContext.Set<T>().Remove(entityToDelete);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
