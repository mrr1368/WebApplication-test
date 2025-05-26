using System.Diagnostics.Metrics;
using System;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebApplication7.Models.Product;

namespace WebApplication7.Context
{
    public class ProductDbContext : DbContext
    {
        public required DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ProductDb;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate = true");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
