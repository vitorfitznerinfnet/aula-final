using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Api.Requests
{
    public class CriarLivroRequest
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string UsuarioDeCadastro { get; set; }
    }
}
