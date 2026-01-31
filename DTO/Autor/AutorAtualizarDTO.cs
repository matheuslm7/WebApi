using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO.Autor
{
    public class AutorAtualizarDTO
    {
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
    }
}