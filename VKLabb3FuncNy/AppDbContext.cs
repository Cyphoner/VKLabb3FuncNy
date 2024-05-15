using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VKLabb3FuncNy
{ 
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions options) : base(options)
            {

            }

            public DbSet<Product> Products { get; set; }
        }
    
}
