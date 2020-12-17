using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaRepuestos.Models
{
    public class Venta
    {
        [Key]
        public int id { get; set; }
        public DateTime Fecha { get; set; }
        public int idCliente { get; set; }
        [ForeignKey("idCliente")]
        public Cliente Cliente { get; set; }
        public List<DetalleVenta> DetallesVenta { get; set; }
    }
}
