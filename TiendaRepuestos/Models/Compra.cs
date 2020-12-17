using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaRepuestos.Models
{
    public class Compra
    {
        [Key]
        public int id { get; set; }
        public DateTime Fecha { get; set; }
        public int idProveedor { get; set; }
        [ForeignKey("idProveedor")]
        public Proveedor Proveedor { get; set; }
        public List<DetalleCompra> DetallesCompra { get; set; }
    }
}
