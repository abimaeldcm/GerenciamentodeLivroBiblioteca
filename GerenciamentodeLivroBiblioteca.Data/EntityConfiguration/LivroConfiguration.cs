using GerenciamentodeLivroBiblioteca.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentodeLivroBiblioteca.Infra.Data.EntityConfiguration
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.Property(p => p.Titulo)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Autor)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
