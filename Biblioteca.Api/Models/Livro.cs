using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Api.Models
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UsuarioCadastro { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public string Autor { get; internal set; }
    }
}
