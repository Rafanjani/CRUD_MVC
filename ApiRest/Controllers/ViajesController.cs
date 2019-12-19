using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Context;
using ApiRest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    public class ViajesController : ControllerBase
    {
        private readonly DefaultContext _context;

        public ViajesController(DefaultContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<Viaje> viajesList;

            try
            {
                viajesList = _context.Viajes.Where(p => p.Eliminado == null).ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(viajesList);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            Viaje viaje;

            try
            {
                viaje = _context.Viajes.Where(p => p.Eliminado == null && p.Id == id).FirstOrDefault();

                if (viaje == null)
                    return NotFound();
                else
                    return Ok(viaje);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]Viaje viaje)
        {
            if (viaje == null)
                return BadRequest();

            try
            {
                Viaje validacion = _context.Viajes.Where(p => p.Codigo == viaje.Codigo && p.Eliminado == null).FirstOrDefault();
                if (validacion != null)
                    return Conflict();

                viaje.Id = 0;
                viaje.Creado = DateTime.Now;
                viaje.Modificado = viaje.Creado;
                viaje.Eliminado = null;

                _context.Add(viaje);
                await _context.SaveChangesAsync();

                return Created(Request.Path.ToString() + "/" + viaje.Id.ToString(), viaje);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]Viaje viajeModificado)
        {
            if (viajeModificado == null)
                return BadRequest();

            try
            {
                Viaje viaje = _context.Viajes.Where(p => p.Id == viajeModificado.Id && p.Eliminado == null).FirstOrDefault();

                if (viaje == null)
                    return NotFound();

                viaje.Codigo = viajeModificado.Codigo;
                viaje.Plazas = viajeModificado.Plazas;
                viaje.Destino = viajeModificado.Destino;
                viaje.Origen = viajeModificado.Origen;
                viaje.Precio = viajeModificado.Precio;
                viaje.Modificado = DateTime.Now;

                _context.Update(viaje);
                await _context.SaveChangesAsync();

                return Ok(viaje);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            try
            {
                Viaje eliminar = _context.Viajes.Where(p => p.Id == id && p.Eliminado == null).FirstOrDefault();
                if (eliminar == null)
                    return NotFound();

                eliminar.Modificado = DateTime.Now;
                eliminar.Eliminado = eliminar.Modificado;

                _context.Update(eliminar);
                await _context.SaveChangesAsync();

                return Ok(eliminar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
