using Ash.Models;
using Ash.Models.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ash.DataAccess.Data
{
    public class ApplicationDataContext : IdentityDbContext
    {
       public ApplicationDataContext(DbContextOptions<ApplicationDataContext> Options) :base (Options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<ApplicationUsers> applicationUsers { get; set; }
        public DbSet<ShoppingCart> ShopingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
