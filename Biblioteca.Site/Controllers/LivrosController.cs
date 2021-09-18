using Biblioteca.Site.Models.Livros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Site.Controllers
{
    public class LivrosController : ControllerBase
    {
        public LivrosController(IHttpClientFactory factory) : base(factory)
        {
            
        }

        // GET: LivrosController
        [Authorize]
        public async Task<ActionResult> Index()
        {
            ViewBag.Livros = await ApiConsulta<List<LivroModel>>("livros");

            return View();
        }

        // GET: LivrosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LivrosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LivrosController/Create
        [HttpPost]
        public async Task<ActionResult> Criar(string nome, string autor)
        {
            var request = new
            {
                Nome = nome,
                Autor = autor,
                UsuarioDeCadastro = User.Identity.Name
            };

            await ApiCadastro(request, "livros");

            return RedirectToAction("index");
        }

        // GET: LivrosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LivrosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LivrosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LivrosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
