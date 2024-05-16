using Microsoft.EntityFrameworkCore;
using PizzaShoppingAPI.Models;
namespace PizzaShoppingAPI.Contexts
{
    public class PizzaShoppingContext : DbContext
    {
        public PizzaShoppingContext(DbContextOptions<PizzaShoppingContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
    
}
