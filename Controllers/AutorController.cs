using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services.Autor;

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








    }

}