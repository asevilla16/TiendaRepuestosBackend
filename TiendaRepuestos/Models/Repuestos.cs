using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaRepuestos.Models
{
    public class Repuestos
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Codigo { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set; }

        [Required]
        public double PrecioCompra { get; set; }

        [Required]
        public double PrecioVenta { get; set; }

        [Required]
        public int idCategoria { get; set; }
        [ForeignKey("idCategoria")]
        public Categoria categoria { get; set; }



    }
}
