using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Viajes.Models;
using MVC_Viajes.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_Viajes.Controllers
{
    public class ViajesController : Controller
    {
        private string _urlContorladorApi = "api/viajes/";

        public async Task<IActionResult> Index()
        {
            List<Viaje> viajeros = await DAO_Api.GetAsync<List<Viaje>>(_urlContorladorApi);

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
        public async Task<IActionResult> Create(Viaje post)
        {
            Viaje viaje = await DAO_Api.PostAsync<Viaje>(_urlContorladorApi, post);

            if (viaje == null)
                return RedirectToAction("Error");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Viaje viaje = await DAO_Api.GetAsync<Viaje>(_urlContorladorApi + id.ToString());

            if (viaje == null)
                return RedirectToAction("Error");

            return View(viaje);
        }

        public async Task<IActionResult> Details(int id)
        {
            Viaje viaje = await DAO_Api.GetAsync<Viaje>(_urlContorladorApi + id.ToString());

            if (viaje == null)
                return RedirectToAction("Error");

            return View(viaje);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Viaje viaje)
        {
            var response = await DAO_Api.PutAsync<Viaje>(_urlContorladorApi, viaje);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Viaje viaje = await DAO_Api.DeleteAsync<Viaje>(_urlContorladorApi + id.ToString());

            if (viaje == null)
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
