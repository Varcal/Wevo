using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Wevo.WebSite.Models;

namespace Wevo.WebSite.Controllers
{
    public class ClientesController : Controller
    {
        private IConfiguration _configuration;

        public ClientesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: Clientes
        public async Task<IActionResult> Index()
        {

            ViewBag.Mensagem = TempData["Mensagem"];


            var apiUrl = _configuration.GetSection("ApiUrl").Value;

            using (var httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) })
            {
                var result = await httpClient.GetAsync("api/clientes");
                var json = await result.Content.ReadAsStringAsync();
                var clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);

                return View(clientes);
            }
        }



        // GET: Clientes/Create
        public ActionResult Registrar()
        {
            ViewBag.Sexo = PopularSelectSexo();
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            var apiUrl = _configuration.GetSection("ApiUrl").Value;

            using (var httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) })
            {
                var json = JsonConvert.SerializeObject(cliente);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var result = await httpClient.PostAsync("api/clientes", data);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    TempData["Mensagem"] = "Cliente registrado com sucesso";
                    return RedirectToAction(nameof(Index));
                }

                return View(cliente);

            }
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Editar(int id)
        {
            var apiUrl = _configuration.GetSection("ApiUrl").Value;

            ViewBag.Sexo = PopularSelectSexo();

            using (var httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) })
            {
                var result = await httpClient.GetAsync($"api/clientes/{id}");
                var json = await result.Content.ReadAsStringAsync();
                var cliente = JsonConvert.DeserializeObject<Cliente>(json);

                return View(cliente);
            }
        }

        private static List<SelectListItem> PopularSelectSexo()
        {
            return new List<SelectListItem>()
                {new SelectListItem("Masculino", "1"), new SelectListItem("Feminino", "2")};
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            var apiUrl = _configuration.GetSection("ApiUrl").Value;

            using (var httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) })
            {
                var json = JsonConvert.SerializeObject(cliente);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type",
                    "application/json; charset=utf-8");
                var result = await httpClient.PutAsync($"/api/clientes/{cliente.Id}", data);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    TempData["Mensagem"] = "Cliente alterado com sucesso";
                    return RedirectToAction(nameof(Index));
                }

                return View(cliente);
            }
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Excluir(int id)
        {
            var apiUrl = _configuration.GetSection("ApiUrl").Value;

            using (var httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) })
            {
                var result = await httpClient.GetAsync($"api/clientes/{id}");
                var json = await result.Content.ReadAsStringAsync();
                var cliente = JsonConvert.DeserializeObject<Cliente>(json);

                return View(cliente);
            }
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(@"Excluir")]
        public async Task<IActionResult> ExcluirPost(int id)
        {
            var apiUrl = _configuration.GetSection("ApiUrl").Value;

            using (var httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) })
            {

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type",
                    "application/json; charset=utf-8");
                var result = await httpClient.DeleteAsync($"/api/clientes/{id}");

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    TempData["Mensagem"] = "Cliente excluido com sucesso";
                }

                return RedirectToAction(nameof(Index));
            }
        }
    }
}