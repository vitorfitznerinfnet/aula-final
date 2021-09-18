using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Biblioteca.Site.Controllers
{
    public class PostsController : ControllerBase
    {
        public PostsController(IHttpClientFactory fac) : base(fac)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Criar(string texto, IFormFile file) 
        {
            var usuario = User.Identity.Name;

            var request = new
            {
                Autor = usuario,
                Texto = texto,
                Imagem = file.FileName
            };

            await ApiCadastro(request, "posts");

            await ApiRemove(123, "livros");

            return View();
        }
    }
}
