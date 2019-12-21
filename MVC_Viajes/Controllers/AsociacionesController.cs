using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Viajes.Models;
using MVC_Viajes.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_Viajes.Controllers
{
    public class AsociacionesController : Controller
    {
        private string _urlContorladorApi = "api/r_viajes_viajeros/";
        private string _urlContorladorViajes = "api/viajes/";
        private string _urlContorladorViajeros = "api/viajeros/";

        public async Task<IActionResult> Index()
        {
            List<R_Viaje_Viajero> asociaciones = await DAO_Api.GetAsync<List<R_Viaje_Viajero>>(_urlContorladorApi);
            List<Vista_Viaje_Viajero> listaViajesViajeros = new List<Vista_Viaje_Viajero>();

            foreach (var item in asociaciones)
            {
                Viaje viaje = await DAO_Api.GetAsync<Viaje>(_urlContorladorViajes + item.Viaje.ToString());
                Viajero viajero = await DAO_Api.GetAsync<Viajero>(_urlContorladorViajeros + item.Viajero.ToString());

                if (viaje != null && viajero != null)
                    listaViajesViajeros.Add(new Vista_Viaje_Viajero() { Viaje = viaje, Viajero = viajero, Id = item.Id });
            }
            
            return View(listaViajesViajeros);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Viaje> viajes = await DAO_Api.GetAsync<List<Viaje>>(_urlContorladorViajes);
            List<Viajero> viajeros = await DAO_Api.GetAsync<List<Viajero>>(_urlContorladorViajeros);

            Lista_Viajes_Viajeros lista = new Lista_Viajes_Viajeros();
            lista.Viajes = viajes;
            lista.Viajeros = viajeros;

            return View(lista);
        }
        
        [HttpGet]
        public async Task<IActionResult> Post([FromQuery]int Viajeros, int Viajes)
        {
            var post = new R_Viaje_Viajero() { Viaje = Viajes, Viajero = Viajeros };

            R_Viaje_Viajero relacion = await DAO_Api.PostAsync<R_Viaje_Viajero>(_urlContorladorApi, post);

            if (relacion == null)
                return RedirectToAction("Error");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            R_Viaje_Viajero relacion = await DAO_Api.DeleteAsync<R_Viaje_Viajero>(_urlContorladorApi + id.ToString());

            if (relacion == null)
                return RedirectToAction("Error");

            return RedirectToAction("Index");
        }
    }
}
