using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO.Livro
{
    public class LivroCriacaoDTO
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required int AutorId { get; set; }
    }
}