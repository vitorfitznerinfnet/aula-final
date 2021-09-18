using Biblioteca.Api.Models;
using Biblioteca.Api.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody]CriarLivroRequest criarLivro)
        {
            var livro = new Livro();
            livro.Id = Guid.NewGuid();
            livro.Nome = criarLivro.Nome;
            livro.Autor = criarLivro.Autor;
            livro.DataDeCadastro = DateTime.Now;
            livro.UsuarioCadastro = criarLivro.UsuarioDeCadastro;

            Salvar(livro);

            return Ok();
        }

        [HttpGet]
        public ActionResult Get([FromQuery] string usuario)
        {
            if (string.IsNullOrEmpty(usuario))
                return Ok(livros);

            var liv = livros.Where(x => x.UsuarioCadastro == usuario);

            return Ok(liv);
        }

        private static List<Livro> livros = new List<Livro>();

        private void Salvar(Livro livro)
        {
            livros.Add(livro);
        }
    }
}
