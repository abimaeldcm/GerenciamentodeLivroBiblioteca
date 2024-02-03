using AutoMapper;
using GerenciamentodeLivroBiblioteca.Application.Services;
using GerenciamentodeLivroBiblioteca.Domain.Entites;
using GerenciamentodeLivroBiblioteca.Domain.Interfaces;
using GerenciamentodeLivroBiblioteca.Infra.Data.Repository;
using GerenciamentodeLivroBiblioteca.Infra.IoC;
using GerenciamentodeLivroBiblioteca.Mapeamentos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace GerenciamentoDeLivroBiblioteca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            Configure(app);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            // Configuração do Swagger
            services.AddEndpointsApiExplorer();
            services.AddControllers();
            services.AddAutoMapper(typeof(MapearEntities));

            services.AddInfrastructure(Configuration);
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Sistema Bibliotecário",
                    Version = "v1",
                    Description = "Este projeto é uma API .NET desenvolvida para gerenciar livros, Usuários e empréstimos de uma biblioteca. A aplicação oferece operações CRUD (Criar, Ler, Atualizar, Excluir) e outras para manipular as funcionalidades no banco de dados. A arquitetura Clean Architecture é usada para garantir uma separação clara de responsabilidades, incluindo camadas de Aplicação, Domínio, Dados e IoC. O código segue princípios de Clean Code para manutenção e legibilidade.",
                    Contact = new OpenApiContact
                    {
                        Name = "Abimael Mendes",
                        Url = new Uri("https://github.com/abimaeldcm"),
                        Email = "abimaelmends@hotmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Linkedin",
                        Url = new Uri("https://www.linkedin.com/in/abimaelmends/")
                    }
                });


            });
        }
        private static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                // Configuração do Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema Bibliotecário - API v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
