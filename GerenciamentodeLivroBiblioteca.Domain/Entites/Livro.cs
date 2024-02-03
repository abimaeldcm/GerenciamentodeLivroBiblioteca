namespace GerenciamentodeLivroBiblioteca.Domain.Entites
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoDePublicacao { get; set; }
        public bool Disponivel { get; set; }
    }
}
