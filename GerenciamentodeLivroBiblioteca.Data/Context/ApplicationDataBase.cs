using GerenciamentodeLivroBiblioteca.Domain.Entites;
using GerenciamentodeLivroBiblioteca.Infra.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentodeLivroBiblioteca.Infra.Data.Context
{
    public class ApplicationDataBase : DbContext
    {
        public ApplicationDataBase(DbContextOptions<ApplicationDataBase> options) : base(options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new LivroConfiguration());
            modelBuilder.ApplyConfiguration(new EmprestimoConfiguration());
        }
    }
}


/*
 protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
 */