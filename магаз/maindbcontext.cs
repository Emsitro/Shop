using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop.models;

namespace shop
{
    public class maindbcontext:DbContext
    {
        public DbSet<product> products { get; set; }
        public DbSet<seller> sellers { get; set; }
        public maindbcontext() {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=192.168.0.222;user=root;password=is410601;database=vadartko");
        }
    }
}
