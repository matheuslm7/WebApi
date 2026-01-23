using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<AutorModel>> ObterAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorbanco => autorbanco.Id == idAutor);
                
                if(autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado";
                    return resposta;
                }
                resposta.Dados = autor;
                resposta.Mensagem = "Autor listado com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public Task<ResponseModel<AutorModel>> ObterAutoPorIdLivro(int idLivro)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores =  await _context.Autores.ToListAsync();
                resposta.Dados = autores;
                resposta.Mensagem = "Autores listados com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}