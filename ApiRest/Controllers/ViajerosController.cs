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
    public class ViajerosController : ControllerBase
    {
        private readonly DefaultContext _context;

        public ViajerosController(DefaultContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<Viajero> viajerosList;

            try
            {
                viajerosList = _context.Viajeros.Where(p => p.Eliminado == null).ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(viajerosList);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            Viajero viajeros;

            try
            {
                viajeros = _context.Viajeros.Where(p => p.Eliminado == null && p.Id == id).FirstOrDefault();

                if (viajeros == null)
                    return NotFound();
                else
                    return Ok(viajeros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]Viajero viajero)
        {
            if (viajero == null || string.IsNullOrEmpty(viajero.Cedula) || string.IsNullOrEmpty(viajero.Nombres) || string.IsNullOrEmpty(viajero.Apellidos))
                return BadRequest();

            try
            {
                Viajero validacion = _context.Viajeros.Where(p => p.Cedula == viajero.Cedula && p.Eliminado == null).FirstOrDefault();
                if (validacion != null)
                    return Conflict();

                viajero.Id = 0;
                viajero.Creado = DateTime.Now;
                viajero.Modificado = viajero.Creado;
                viajero.Eliminado = null;

                _context.Add(viajero);
                await _context.SaveChangesAsync();

                return Created(Request.Path.ToString() + "/" + viajero.Id.ToString(), viajero);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]Viajero viajeroModificado)
        {
            if (viajeroModificado == null)
                return BadRequest();

            try
            {
                Viajero viajero = _context.Viajeros.Where(p => p.Id == viajeroModificado.Id && p.Eliminado == null).FirstOrDefault();

                if (viajero == null)
                    return NotFound();

                viajero.Cedula = viajeroModificado.Cedula;
                viajero.Nombres = viajeroModificado.Nombres;
                viajero.Apellidos = viajeroModificado.Apellidos;
                viajero.Direccion = viajeroModificado.Direccion;
                viajero.Telefono = viajeroModificado.Telefono;
                viajero.Modificado = DateTime.Now;

                _context.Update(viajero);
                await _context.SaveChangesAsync();

                return Ok(viajero);
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
                Viajero eliminar = _context.Viajeros.Where(p => p.Id == id && p.Eliminado == null).FirstOrDefault();
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
