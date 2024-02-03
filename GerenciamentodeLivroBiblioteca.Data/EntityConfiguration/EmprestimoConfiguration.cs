using GerenciamentodeLivroBiblioteca.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace GerenciamentodeLivroBiblioteca.Infra.Data.EntityConfiguration
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.HasOne(e => e.UsuarioNav)
            .WithMany()
            .HasForeignKey(e => e.IdUsuario)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.LivroNav)
            .WithMany()
            .HasForeignKey(e => e.IdLivro)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
