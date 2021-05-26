using Microsoft.EntityFrameworkCore;
using PracticaN3.Models;

namespace PracticaN3.Data
{
    public class BuscoContext : DbContext
    {
        public DbSet<Producto> Productos{ get; set; }
        public DbSet<Categoria> Categorias{ get; set; }

        public BuscoContext(DbContextOptions dco ) : base(dco){

        }
    }
}