using LaMiaPizzeria.Models;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeria.DataBase
{
    public class PizzaContext : DbContext
    {
        public DbSet<PizzaModel> Pizze { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PizzaDb;Integrated Security=True;TrustServerCertificate=True");
    }
    }
}
