using System.ComponentModel.DataAnnotations;

namespace GerenciamentodeLivroBiblioteca.Domain.Entites
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
