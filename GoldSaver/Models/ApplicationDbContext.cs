using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GoldSaver.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User_Category> UserCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}