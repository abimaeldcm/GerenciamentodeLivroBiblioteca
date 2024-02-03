using GerenciamentodeLivroBiblioteca.Application.Services;
using GerenciamentodeLivroBiblioteca.Domain.Entites;
using GerenciamentodeLivroBiblioteca.Domain.Interfaces;
using GerenciamentodeLivroBiblioteca.Infra.Data.Context;
using GerenciamentodeLivroBiblioteca.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciamentodeLivroBiblioteca.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                      IConfiguration Configuration)
        {
            //Acesso ao Banco de dados
            services.AddDbContext<ApplicationDataBase>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DataBase"),
                b => b.MigrationsAssembly(typeof(ApplicationDataBase).Assembly.FullName)));

            // Injeções de Dependências
            services.AddScoped<IlivroServices, LivroServices>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IRepository<Usuario>, EntityRepository<Usuario>>();
            services.AddScoped<IRepository<Livro>, EntityRepository<Livro>>();
            services.AddScoped<IRepository<Emprestimo>, EntityRepository<Emprestimo>>();

            services.AddScoped<IEmprestimoService, EmprestimoService>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
            return services;
        }
    }
}
