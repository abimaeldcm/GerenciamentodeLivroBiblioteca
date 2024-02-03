namespace GerenciamentodeLivroBiblioteca.Domain.DTOs
{
    public class EmprestimoDTO
    {
        public class EmprestimoBuscarDTO
        {
            public int Id { get; set; }
            public int IdUsuario { get; set; }
            public int IdLivro { get; set; }
            public DateTime DataEmprestimo { get; set; }
        }

        public class EmprestimoCadastrarDTO
        {
            public int IdUsuario { get; set; }
            public int IdLivro { get; set; }
        }
    }

}
