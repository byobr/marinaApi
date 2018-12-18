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
    [Route("api/alimentos")]
    [ApiController]
    public class AlimentosController : ControllerBase
    {
        private readonly Banco _context;

        public AlimentosController(Banco context)
        {
            _context = context;
        }

        // GET: api/Alimentos
        [HttpGet]
        public IEnumerable<Alimentos> Getalimentos()
        {
            IEnumerable<Alimentos> retorno = _context.alimentos.Include(i => i.categoria);
            return retorno;
        }

        // GET: api/Alimentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlimentos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alimentos = await _context.alimentos.FindAsync(id);

            if (alimentos == null)
            {
                return NotFound();
            }

            return Ok(alimentos);
        }

        // PUT: api/Alimentos/5
        [HttpPut]
        public async Task<IActionResult> PutAlimentos([FromBody] Alimentos alimentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (alimentos.id != alimentos.id)
            {
                return BadRequest();
            }

            _context.Entry(alimentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlimentosExists(alimentos.id))
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

        // POST: api/Alimentos
        [HttpPost]
        public async Task<IActionResult> PostAlimentos([FromBody] Alimentos alimentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            alimentos.categoria = _context.categoriaAlimentos.FirstOrDefault(w => w.id == alimentos.categoria.id);
            _context.alimentos.Add(alimentos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlimentos", new { id = alimentos.id }, alimentos);
        }

        // DELETE: api/Alimentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlimentos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alimentos = await _context.alimentos.FindAsync(id);
            if (alimentos == null)
            {
                return NotFound();
            }

            _context.alimentos.Remove(alimentos);
            await _context.SaveChangesAsync();

            return Ok(alimentos);
        }

        private bool AlimentosExists(int id)
        {
            return _context.alimentos.Any(e => e.id == id);
        }
    }
}