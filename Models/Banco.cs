using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApiMarina.Models.Domain;

namespace webApiMarina.Models
{
    public class Banco : DbContext
    {
        public Banco(DbContextOptions<Banco> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=bancofiuza.database.windows.net;Initial Catalog=marinaWeb;Persist Security Info=True;User ID=fiuza;Password=1111111111111111");
        }
        public DbSet<Alimentos> alimentos { get; set; }
        public DbSet<CategoriaAlimentos> categoriaAlimentos { get; set; }
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Consultas> consultas { get; set; }
        public DbSet<ConsultaAlimentos> consultaAlimentos { get; set; }
    }
}
