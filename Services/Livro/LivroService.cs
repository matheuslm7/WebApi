using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.DTO.Livro;
using WebApi.Models;

namespace WebApi.Services.Livro
{
    public class LivroService : ILivroInterface

    {
        private readonly AppDbContext _context;
        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<List<LivroModel>>> AtualizarLivro(int idLivro, LivroAtualizarDTO livroAtualizarDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDTO livroCriacaoDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<LivroModel>> DeletarLivro(int idLivro)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<LivroModel>> ObterLivroPorId(int idLivro)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<LivroModel>> ObterLivroPorIdAutor(int idAutor)
        {
            throw new NotImplementedException();
        }
    }
}