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
    [Route("api/consulta-alimentos")]
    [ApiController]
    public class ConsultaAlimentosController : ControllerBase
    {
        private readonly Banco _context;

        public ConsultaAlimentosController(Banco context)
        {
            _context = context;
        }

        // GET: api/ConsultaAlimentos
        [HttpGet]
        public IEnumerable<ConsultaAlimentos> GetconsultaAlimentos()
        {
            return _context.consultaAlimentos;
        }

        // GET: api/ConsultaAlimentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsultaAlimentos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consultaAlimentos = await _context.consultaAlimentos.FindAsync(id);

            if (consultaAlimentos == null)
            {
                return NotFound();
            }

            return Ok(consultaAlimentos);
        }

        // PUT: api/ConsultaAlimentos/5
        [HttpPut]
        public async Task<IActionResult> PutConsultaAlimentos([FromBody] ConsultaAlimentos consultaAlimentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (consultaAlimentos.id != consultaAlimentos.id)
            {
                return BadRequest();
            }

            _context.Entry(consultaAlimentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaAlimentosExists(consultaAlimentos.id))
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

        // POST: api/ConsultaAlimentos
        [HttpPost]
        public async Task<IActionResult> PostConsultaAlimentos([FromBody] ConsultaAlimentos consultaAlimentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.consultaAlimentos.Add(consultaAlimentos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultaAlimentos", new { id = consultaAlimentos.id }, consultaAlimentos);
        }

        // DELETE: api/ConsultaAlimentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultaAlimentos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consultaAlimentos = await _context.consultaAlimentos.FindAsync(id);
            if (consultaAlimentos == null)
            {
                return NotFound();
            }

            _context.consultaAlimentos.Remove(consultaAlimentos);
            await _context.SaveChangesAsync();

            return Ok(consultaAlimentos);
        }

        private bool ConsultaAlimentosExists(int id)
        {
            return _context.consultaAlimentos.Any(e => e.id == id);
        }
    }
}