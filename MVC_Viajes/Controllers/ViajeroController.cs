using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Viajes.Models;
using MVC_Viajes.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_Viajes.Controllers
{
    public class ViajeroController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Viajero> viajeros = await DAO_Api.GetAsync<List<Viajero>>("api/viajeros/");

            if (viajeros == null)
                return RedirectToAction("Error");

            return View(viajeros);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Viajero post)
        {
            Viajero viajero = await DAO_Api.PostAsync<Viajero>("api/viajeros/", post);

            if (viajero == null)
                return RedirectToAction("Error");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Viajero viajero = await DAO_Api.GetAsync<Viajero>("api/viajeros/" + id.ToString());

            if (viajero == null)
                return RedirectToAction("Error");

            return View(viajero);
        }

        public async Task<IActionResult> Details(int id)
        {
            Viajero viajero = await DAO_Api.GetAsync<Viajero>("api/viajeros/" + id.ToString());

            if (viajero == null)
                return RedirectToAction("Error");

            return View(viajero);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Viajero viajero)
        {
            var response = await DAO_Api.PutAsync<Viajero>("api/viajeros/", viajero);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Viajero viajero = await DAO_Api.DeleteAsync<Viajero>("api/viajeros/" + id.ToString());

            if (viajero == null)
                return RedirectToAction("Error");

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
