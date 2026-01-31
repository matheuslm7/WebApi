using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO.Livro;
using WebApi.Models;

namespace WebApi.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> ObterLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> ObterLivroPorIdAutor(int idAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDTO livroCriacaoDTO);

        Task<ResponseModel<LivroModel>> DeletarLivro(int idLivro);
        Task<ResponseModel<List<LivroModel>>> AtualizarLivro(int idLivro, LivroAtualizarDTO livroAtualizarDTO);
    }
}