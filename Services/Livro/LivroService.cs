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

        public async Task<ResponseModel<LivroModel>> ObterLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros
                    .Include(l => l.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado";
                    return resposta;
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Livro listado com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ObterLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros
                    .Include(l => l.Autor)
                    .Where(livroBanco => livroBanco.Autor.Id == idAutor)
                    .ToListAsync();

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum livro encontrado para este autor";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Livro listado com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDTO livroCriacaoDTO)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == livroCriacaoDTO.AutorId);

                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Titulo = livroCriacaoDTO.Titulo,
                    Autor = autor
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(l => l.Autor).ToListAsync();
                resposta.Mensagem = "Livro criado com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> AtualizarLivro(int idLivro, LivroAtualizarDTO livroAtualizarDTO)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.
                Include(a => a.Autor)
                .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                var autor = await _context.Autores
                .FirstOrDefaultAsync(a => a.Id == livroAtualizarDTO.AutorId);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro de livro localizado!";
                    return resposta;
                }
                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado";
                    return resposta;
                }
                livro.Titulo = livroAtualizarDTO.Titulo;
                livro.Autor = autor;

                _context.Livros.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(l => l.Autor).ToListAsync();
                resposta.Mensagem = "Livro atualizado com sucesso!";
                resposta.Status = true;
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroModel>> DeletarLivro(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro de livro localizado!";
                    return resposta;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = livro;
                resposta.Mensagem = "Livro deletado com sucesso!";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros.Include(l => l.Autor).ToListAsync();
                resposta.Dados = livros;
                resposta.Mensagem = "Livros listados com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}