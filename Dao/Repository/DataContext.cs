using EzPaymentBot.Dao.Models;
using Microsoft.EntityFrameworkCore;

namespace EzPaymentBot.Dao.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<TelegramChannel> Channels { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Ezdb;Trusted_Connection=True;");
        }
    }
}
