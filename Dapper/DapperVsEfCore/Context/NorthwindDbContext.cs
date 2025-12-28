using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperVsEfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace DapperVsEfCore.Context
{
    public class NorthWindDbContext : DbContext
    {
        public NorthWindDbContext()
        {
        }
        public NorthWindDbContext(DbContextOptions<NorthWindDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
    }
}
