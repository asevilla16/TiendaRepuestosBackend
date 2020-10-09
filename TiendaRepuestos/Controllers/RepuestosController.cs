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
    public class RepuestosController : ControllerBase
    {
        private readonly DataContext _context;

        public RepuestosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Repuestos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repuestos>>> Getrepuestos()
        {
            return await _context.repuestos.Include(q => q.categoria).ToListAsync();
        }

        // GET: api/Repuestos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Repuestos>> GetRepuestos(int id)
        {
            var repuestos = await _context.repuestos.FindAsync(id);

            if (repuestos == null)
            {
                return NotFound();
            }

            return repuestos;
        }

        // PUT: api/Repuestos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepuestos(int id, Repuestos repuestos)
        {
            if (id != repuestos.id)
            {
                return BadRequest();
            }

            _context.Entry(repuestos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepuestosExists(id))
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

        // POST: api/Repuestos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Repuestos>> PostRepuestos(Repuestos repuestos)
        {
            _context.repuestos.Add(repuestos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepuestos", new { id = repuestos.id }, repuestos);
        }

        // DELETE: api/Repuestos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Repuestos>> DeleteRepuestos(int id)
        {
            var repuestos = await _context.repuestos.FindAsync(id);
            if (repuestos == null)
            {
                return NotFound();
            }

            _context.repuestos.Remove(repuestos);
            await _context.SaveChangesAsync();

            return repuestos;
        }

        private bool RepuestosExists(int id)
        {
            return _context.repuestos.Any(e => e.id == id);
        }
    }
}
