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
    public class RegistroIngresosController : ControllerBase
    {
        private readonly DataContext _context;

        public RegistroIngresosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/RegistroIngresos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroIngreso>>> GetregistroIngresos()
        {
            return await _context.registroIngresos.ToListAsync();
        }

        // GET: api/RegistroIngresos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroIngreso>> GetRegistroIngreso(int id)
        {
            var registroIngreso = await _context.registroIngresos.FindAsync(id);

            if (registroIngreso == null)
            {
                return NotFound();
            }

            return registroIngreso;
        }

        // PUT: api/RegistroIngresos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroIngreso(int id, RegistroIngreso registroIngreso)
        {
            if (id != registroIngreso.id)
            {
                return BadRequest();
            }

            _context.Entry(registroIngreso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroIngresoExists(id))
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

        // POST: api/RegistroIngresos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RegistroIngreso>> PostRegistroIngreso(RegistroIngreso registroIngreso)
        {
            _context.registroIngresos.Add(registroIngreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroIngreso", new { id = registroIngreso.id }, registroIngreso);
        }

        // DELETE: api/RegistroIngresos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistroIngreso>> DeleteRegistroIngreso(int id)
        {
            var registroIngreso = await _context.registroIngresos.FindAsync(id);
            if (registroIngreso == null)
            {
                return NotFound();
            }

            _context.registroIngresos.Remove(registroIngreso);
            await _context.SaveChangesAsync();

            return registroIngreso;
        }

        private bool RegistroIngresoExists(int id)
        {
            return _context.registroIngresos.Any(e => e.id == id);
        }
    }
}
