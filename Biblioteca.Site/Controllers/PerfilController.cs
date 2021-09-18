using Biblioteca.Site.Models.Perfil;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Site.Controllers
{
    public class PerfilController : ControllerBase
    {
        public PerfilController(IHttpClientFactory factory) : base(factory)
        {
        }

        public async Task<IActionResult> Index()
        {
            var resultado = await ApiConsulta<PerfilIndexModel>("perfil");

            return View(resultado);
        }

        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Criar(string nome, string endereco, string telefone)
        {
            var dono = User.Identity.Name;

            var request = new
            {
                Nome = nome,
                Endereco = endereco,
                Dono = dono
            };

            await ApiCadastro(request, "perfil");

            return RedirectToAction("index", "livros");
        }
    }
}
