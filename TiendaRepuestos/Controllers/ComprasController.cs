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
    public class ComprasController : ControllerBase
    {
        private readonly DataContext _context;

        public ComprasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> GetCompras()
        {
            var list = await _context.Compras.Include(p => p.Proveedor).Include(l => l.DetallesCompra).ToListAsync();
            return list;
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> GetCompra(int id)
        {
            var compra = await _context.Compras.Include(p => p.Proveedor).Include(l => l.DetallesCompra).FirstOrDefaultAsync(x => x.id == id);

            if (compra == null)
            {
                return NotFound();
            }

            return compra;
        }

        [HttpPost]
        public async Task<ActionResult<Compra>> PostCompra(Compra compra)
        {

            Compra c = new Compra();
            c.Fecha = compra.Fecha;
            c.idProveedor = compra.idProveedor;

            _context.Compras.Add(c);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest();
            }

            foreach(DetalleCompra item in compra.DetallesCompra)
            {
                _context.DetalleCompras.Add(new DetalleCompra() 
                {
                    Cantidad = item.Cantidad,
                    idRepuesto = item.idRepuesto,
                    idCompra = c.id,

                });
                await _context.SaveChangesAsync();

                _context.Inventario.Add(new Inventario()
                {
                    Cantidad = item.Cantidad,
                    idRepuesto = item.idRepuesto
                });

                await _context.SaveChangesAsync();

            }
            

            return CreatedAtAction("GetCompra", new { id = compra.id }, compra);
        }
    }
}
