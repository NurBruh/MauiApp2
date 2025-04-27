using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp2.Models;

namespace MauiApp2.Services
{
    public class MySqlDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=whispr-whispr.l.aivencloud.com;port=20839;database=mobile;user=avnadmin;password=AVNS_UdWfnHm5Skw9Y_mazPU;";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
         .HasOne(b => b.User)
         .WithMany(u => u.Books)
         .HasForeignKey(b => b.UserId)
         .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
