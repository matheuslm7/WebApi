using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public ICollection<LivroModel> Livros { get; set; }
    }
}