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
    public class CitasController : Controller
    {
        private readonly string apiUrl;

        public CitasController(IConfiguration configuration)
        {
            apiUrl = configuration["ApiUrl"] + "/Cita";
        }
        // GET: Citas
        public async Task<IActionResult> Index()
        {
            List<Cita> citas = new List<Cita>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    citas = JsonConvert.DeserializeObject<List<Cita>>(data);
                }
            }
            return View(citas);
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Cita cita = new Cita();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    cita = JsonConvert.DeserializeObject<Cita>(data);
                }
            }
            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Citas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,PacienteId,MedicoId,ClinicaId")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var content = new StringContent(JsonConvert.SerializeObject(cita), System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Cita cita = new Cita();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    cita = JsonConvert.DeserializeObject<Cita>(data);
                }
            }
            return View(cita);
        }

        // POST: Citas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,PacienteId,MedicoId,ClinicaId")] Cita cita)
        {
            if (id != cita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var content = new StringContent(JsonConvert.SerializeObject(cita), System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync($"{apiUrl}/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Cita cita = new Cita();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    cita = JsonConvert.DeserializeObject<Cita>(data);
                }
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
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
