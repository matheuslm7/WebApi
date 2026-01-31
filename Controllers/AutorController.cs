using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services.Autor;
using WebApi.DTO.Autor;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AutorController : ControllerBase
    {
        

        private readonly IAutorInterface _autorService;
        public AutorController(IAutorInterface autorService)
        {
            _autorService = autorService;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorService.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("ObterAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> ObterAutorPorId(int idAutor)
        {
            var autor = await _autorService.ObterAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpGet("ObterAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> ObterAutorPorIdLivro(int idLivro)
        {
            var autor = await _autorService.ObterAutorPorIdLivro(idLivro);
            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorCriacaoDTO autorCriacaoDTO)
        {
            var autores = await _autorService.CriarAutor(autorCriacaoDTO);
            return Ok(autores);
        }








    }

}