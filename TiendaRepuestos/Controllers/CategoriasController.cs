using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaRepuestos.DataTienda;
using TiendaRepuestos.Models;

namespace TiendaRepuestos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriasController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            return await _context.categorias.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var category = await _context.categorias.FindAsync(id);

            if (category.Equals(null))
            {
                return NotFound();
            }

            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> PostAlumno(Categoria item)
        {
            _context.categorias.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoria), new { id = item.id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumno(int id, Categoria item)
        {
            if (id != item.id) {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var category = await _context.categorias.FindAsync(id);

            if (category.Equals(null))
            {
                return NotFound();
            }

            _context.categorias.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
