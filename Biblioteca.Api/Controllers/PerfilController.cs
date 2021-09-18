using Biblioteca.Api.Models;
using Biblioteca.Api.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Api.Controllers
{
    [Route("api/perfil")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] CriarPerfilRequest req)
        {
            var perfil = new Perfil();
            perfil.Nome = req.Nome;
            perfil.Dono = req.Dono;
            perfil.Endereco = req.Endereco;
            perfil.Telefone = req.Telefone;

            Salvar(perfil);

            return Ok();
        }

        [HttpGet]
        public ActionResult GetByDono([FromQuery] string dono)
        {
            if (string.IsNullOrEmpty(dono))
                return Ok(perfils);

            var perfil = perfils.FirstOrDefault(x => x.Dono == dono);

            if (perfil == null)
                return NotFound();

            return Ok(perfil);
        }

        private static List<Perfil> perfils = new List<Perfil>();

        private void Salvar(Perfil arg)
        {
            perfils.Add(arg);
        }
    }
}
