namespace GerenciamentodeLivroBiblioteca.Domain.DTOs
{
    public class LivroDTO
    {
        public class LivroBuscarDTO
        {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public string ISBN { get; set; }
            public int AnoDePublicacao { get; set; }
            public bool Disponivel { get; set; }
        }
        public class LivroCadastrarDTO
        {
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public string ISBN { get; set; }
            public int AnoDePublicacao { get; set; }
            public bool Disponivel { get; set; }
        }
    }

}
