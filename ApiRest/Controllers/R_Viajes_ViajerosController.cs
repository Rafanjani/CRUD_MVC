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
    public class R_Viajes_ViajerosController : ControllerBase
    {
        private readonly DefaultContext _context;

        public R_Viajes_ViajerosController(DefaultContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<R_Viaje_Viajero> relacionalList;

            try
            {
                relacionalList = _context.Viajes_Viajeros.Where(p => p.Eliminado == null).ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(relacionalList);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            R_Viaje_Viajero relacional;

            try
            {
                relacional = _context.Viajes_Viajeros.Where(p => p.Eliminado == null && p.Id == id).FirstOrDefault();

                if (relacional == null)
                    return NotFound();
                else
                    return Ok(relacional);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]R_Viaje_Viajero relacional)
        {
            if (relacional == null || relacional.Viaje < 1 || relacional.Viajero <1)
                return BadRequest();

            try
            {
                R_Viaje_Viajero validacion = _context.Viajes_Viajeros.Where(p => p.Viaje == relacional.Viaje && p.Viajero == relacional.Viajero && p.Eliminado == null).FirstOrDefault();
                if (validacion != null)
                    return Conflict();

                relacional.Id = 0;
                relacional.Creado = DateTime.Now;
                relacional.Modificado = relacional.Creado;
                relacional.Eliminado = null;

                _context.Add(relacional);
                await _context.SaveChangesAsync();

                return Created(Request.Path.ToString() + "/" + relacional.Id.ToString(), relacional);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]R_Viaje_Viajero relacionalModificado)
        {
            if (relacionalModificado == null || relacionalModificado.Viaje < 1 || relacionalModificado.Viajero < 1)
                return BadRequest();

            try
            {
                R_Viaje_Viajero relacional = _context.Viajes_Viajeros.Where(p => p.Id == relacionalModificado.Id && p.Eliminado == null).FirstOrDefault();

                if (relacional == null)
                    return NotFound();

                relacional.Viaje = relacionalModificado.Viaje;
                relacional.Viajero = relacionalModificado.Viajero;
                relacional.Modificado = DateTime.Now;

                _context.Update(relacional);
                await _context.SaveChangesAsync();

                return Ok(relacional);
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
                R_Viaje_Viajero eliminar = _context.Viajes_Viajeros.Where(p => p.Id == id && p.Eliminado == null).FirstOrDefault();
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
