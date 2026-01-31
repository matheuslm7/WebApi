using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO.Autor;
using WebApi.Models;

namespace WebApi.DTO.Livro
{
    public class LivroAtualizarDTO
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required int AutorId { get; set; }
    }
}