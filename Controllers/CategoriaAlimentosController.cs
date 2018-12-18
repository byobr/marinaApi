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
    [Route("api/categoria-alimentos")]
    [ApiController]
    public class CategoriaAlimentosController : ControllerBase
    {
        private readonly Banco _context;

        public CategoriaAlimentosController(Banco context)
        {
            _context = context;
        }

        // GET: api/CategoriaAlimentos
        [HttpGet]
        public IEnumerable<CategoriaAlimentos> GetcategoriaAlimentos()
        {
            return _context.categoriaAlimentos;
        }

        // GET: api/CategoriaAlimentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaAlimentos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriaAlimentos = await _context.categoriaAlimentos.FindAsync(id);

            if (categoriaAlimentos == null)
            {
                return NotFound();
            }

            return Ok(categoriaAlimentos);
        }

        // PUT: api/CategoriaAlimentos/5
        [HttpPut]
        public async Task<IActionResult> PutCategoriaAlimentos([FromBody] CategoriaAlimentos categoriaAlimentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (categoriaAlimentos.id != categoriaAlimentos.id)
            {
                return BadRequest();
            }

            _context.Entry(categoriaAlimentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaAlimentosExists(categoriaAlimentos.id))
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

        // POST: api/CategoriaAlimentos
        [HttpPost]
        public async Task<IActionResult> PostCategoriaAlimentos([FromBody] CategoriaAlimentos categoriaAlimentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.categoriaAlimentos.Add(categoriaAlimentos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaAlimentos", new { id = categoriaAlimentos.id }, categoriaAlimentos);
        }

        // DELETE: api/CategoriaAlimentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaAlimentos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriaAlimentos = await _context.categoriaAlimentos.FindAsync(id);
            if (categoriaAlimentos == null)
            {
                return NotFound();
            }

            _context.categoriaAlimentos.Remove(categoriaAlimentos);
            await _context.SaveChangesAsync();

            return Ok(categoriaAlimentos);
        }

        private bool CategoriaAlimentosExists(int id)
        {
            return _context.categoriaAlimentos.Any(e => e.id == id);
        }
    }
}