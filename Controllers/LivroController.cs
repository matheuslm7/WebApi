using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services.Livro;
using WebApi.DTO.Livro;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroService;
        public LivroController(ILivroInterface livroService)
        {
            _livroService = livroService;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroService.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("ObterLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ObterLivroPorId(int idLivro)
        {
            var livro = await _livroService.ObterLivroPorId(idLivro);
            return Ok(livro);
        }

        [HttpGet("ObterLivroPorIdAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ObterLivroPorIdAutor(int idAutor)
        {
            var livro = await _livroService.ObterLivroPorIdAutor(idAutor);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDTO livroCriacaoDTO)
        {
            var livros = await _livroService.CriarLivro(livroCriacaoDTO);
            return Ok(livros);
        }

        [HttpPut("AtualizarLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> AtualizarLivro(int idLivro, LivroAtualizarDTO livroAtualizarDTO)
        {
            var livros = await _livroService.AtualizarLivro(idLivro, livroAtualizarDTO);
            return Ok(livros);
        }

        [HttpDelete("DeletarLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> DeletarLivro(int idLivro)
        {
            var livro = await _livroService.DeletarLivro(idLivro);
            return Ok(livro);
        }
    }
}