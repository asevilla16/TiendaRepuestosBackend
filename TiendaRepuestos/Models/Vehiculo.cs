using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaRepuestos.Models
{
    public class Vehiculo
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Placa { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Marca { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Color { get; set; }

        [Required]
        public string Kilometraje { get; set; }

    }
}
