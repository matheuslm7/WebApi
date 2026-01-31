using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO.Autor;
using WebApi.Models;

namespace WebApi.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> ObterAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> ObterAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDTO autorCriacaoDTO);
        Task<ResponseModel<List<AutorModel>>> AtualizarAutor(int idAutor, AutorAtualizarDTO autorAtualizarDTO);
    }
}