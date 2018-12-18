using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiMarina.Models;
using webApiMarina.Models.Domain;

namespace webApiMarina.Controllers
{
    [Route("api/consultas")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly Banco _context;

        public ConsultasController(Banco context)
        {
            _context = context;
        }

        // GET: api/Consultas
        [HttpGet]
        public IEnumerable<Consultas> Getconsultas()
        {
            return _context.consultas;
        }

        // GET: api/Consultas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsultas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consultas = await _context.consultas.FindAsync(id);

            if (consultas == null)
            {
                return NotFound();
            }

            return Ok(consultas);
        }

        // PUT: api/Consultas/5
        [HttpPut]
        public async Task<IActionResult> PutConsultas([FromBody] Consultas consultas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (consultas.id != consultas.id)
            {
                return BadRequest();
            }

            _context.Entry(consultas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultasExists(consultas.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Consultas
        [HttpPost]
        public async Task<IActionResult> PostConsultas([FromBody] Consultas consultas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.consultas.Add(consultas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultas", new { id = consultas.id }, consultas);
        }

        // DELETE: api/Consultas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consultas = await _context.consultas.FindAsync(id);
            if (consultas == null)
            {
                return NotFound();
            }

            _context.consultas.Remove(consultas);
            await _context.SaveChangesAsync();

            return Ok(consultas);
        }

        private bool ConsultasExists(int id)
        {
            return _context.consultas.Any(e => e.id == id);
        }
    }
}