using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaControlCitasMedicasMVC.Models;

namespace SistemaControlCitasMedicasMVC.Controllers
{
    public class ClinicasController : Controller
    {
        private readonly string apiUrl;

        public ClinicasController(IConfiguration configuration)
        {
            apiUrl = configuration["ApiUrl"] + "/Clinica";
        }
        // GET: Clinicas
        public async Task<IActionResult> Index()
        {
            List<Clinica> clinicas = new List<Clinica>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    clinicas = JsonConvert.DeserializeObject<List<Clinica>>(data);
                }
            }
            return View(clinicas);
        }

        // GET: Clinicas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Clinica clinica = new Clinica();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    clinica = JsonConvert.DeserializeObject<Clinica>(data);
                }
            }
            return View(clinica);
        }

        // GET: Clinicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clinicas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var content = new StringContent(JsonConvert.SerializeObject(clinica), System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(clinica);
        }

        // GET: Clinicas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Clinica clinica = new Clinica();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    clinica = JsonConvert.DeserializeObject<Clinica>(data);
                }
            }
            return View(clinica);
        }

        // POST: Clinicas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion")] Clinica clinica)
        {
            if (id != clinica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var content = new StringContent(JsonConvert.SerializeObject(clinica), System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync($"{apiUrl}/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(clinica);
        }

        // GET: Clinicas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Clinica clinica = new Clinica();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    clinica = JsonConvert.DeserializeObject<Clinica>(data);
                }
            }
            return View(clinica);
        }

        // POST: Clinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
    }
}
