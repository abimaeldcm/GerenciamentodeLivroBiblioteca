using AutoMapper;
using GerenciamentodeLivroBiblioteca.Domain.DTOs;
using GerenciamentodeLivroBiblioteca.Domain.Entites;

namespace GerenciamentodeLivroBiblioteca.Mapeamentos
{
    public class MapearEntities : Profile 
    {
        public MapearEntities()
        {
            CreateMap<Emprestimo, EmprestimoDTO.EmprestimoBuscarDTO>().ReverseMap();
            CreateMap<Emprestimo, EmprestimoDTO.EmprestimoCadastrarDTO>().ReverseMap();

            CreateMap<Livro, LivroDTO.LivroCadastrarDTO>().ReverseMap();
            CreateMap<Livro, LivroDTO.LivroBuscarDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioDTO.UsuarioBuscaDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO.UsuarioBuscaDTO>().ReverseMap();
        }
    }
}
