using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
                
        }

        public ApplicationDbContext(DbContextOptions options)
            :base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=RealEstates; Integrated Sequrity=true");
            }
        }
    }
}
