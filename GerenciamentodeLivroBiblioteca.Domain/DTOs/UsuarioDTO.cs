using System.ComponentModel.DataAnnotations;

namespace GerenciamentodeLivroBiblioteca.Domain.DTOs
{
    public class UsuarioDTO
    {
        public class UsuarioBuscaDTO
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            [EmailAddress]
            public string Email { get; set; }
        }
        public class UsuarioCadastroDTO
        {
            public string Nome { get; set; }
            [EmailAddress]
            public string Email { get; set; }
        }
    }

}
