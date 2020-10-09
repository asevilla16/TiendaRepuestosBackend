using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaRepuestos.Models
{
    public class RegistroIngreso
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Ingreso { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        [Required]
        public int idVehiculo { get; set; }
        [ForeignKey("idVehiculo")]
        public Vehiculo vehiculo { get; set; }

        [Required]
        public int idCliente { get; set; }
        [ForeignKey("idCliente")]
        public Cliente cliente { get; set; }

    }
}
