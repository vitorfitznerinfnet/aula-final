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
    public abstract class ControllerBase : Controller
    {
        public ControllerBase(IHttpClientFactory factory)
        {
            httpClient = factory.CreateClient();
        }

        private HttpClient httpClient;

        private string host = "https://localhost:44307/api";

        public async Task<TipoRetorno> ApiConsulta<TipoRetorno>(string path)
        {
            var response = await httpClient.GetAsync($"{host}/{path}");

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TipoRetorno>(responseContent);
        }

        public async Task ApiCadastro(object objeto, string path)
        {
            var json = JsonConvert.SerializeObject(objeto);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await httpClient.PostAsync($"{host}/{path}", content);
        }

        public async Task ApiRemove(object id, string path)
        {
            await httpClient.DeleteAsync($"{host}/{path}/{id}");
        }
    }
}
