using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaRepuestos.Models
{
    public class Inventario
    {
        [Key]
        public int id { get; set; }
        public int Cantidad { get; set; }
        public int idRepuesto { get; set; }
        [ForeignKey("idRepuesto")]
        public Repuestos Repuesto { get; set; }
    }
}
