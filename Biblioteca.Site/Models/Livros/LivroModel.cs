using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Site.Models.Livros
{
    public class LivroModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public DateTime DataDeCadastro { get; set; }
    }
}
