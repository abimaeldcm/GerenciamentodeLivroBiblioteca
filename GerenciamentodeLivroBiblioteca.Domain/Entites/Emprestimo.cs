using System.Runtime.Serialization;

namespace GerenciamentodeLivroBiblioteca.Domain.Entites
{
    public class Emprestimo
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }
        public Usuario UsuarioNav { get; set; }

        public int IdLivro { get; set; }
        public Livro LivroNav { get; set; }

        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
    }
}
