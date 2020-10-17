using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaRepuestos.Models;

namespace TiendaRepuestos.DataTienda
{
    public class DataContext : DbContext
    {
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Vehiculo> vehiculos { get; set; }
        public DbSet<Repuestos> repuestos { get; set; }
        public DbSet<Categoria> categorias { get; set; }    
        public DbSet<RegistroIngreso> registroIngresos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=DESKTOP-1JU9H2N;DataBase=TiendaRepuestos;Trusted_Connection=True");
        }

        public DbSet<Inventario> Inventario { get; set; }

        public DbSet<Venta> Venta { get; set; }

        public DbSet<DetalleVenta> DetalleVenta { get; set; }
    }
}
