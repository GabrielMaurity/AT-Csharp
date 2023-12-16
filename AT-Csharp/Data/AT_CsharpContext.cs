using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AT_Csharp.Models;

namespace AT_Csharp.Data
{
    public class AT_CsharpContext : DbContext
    {
        public AT_CsharpContext (DbContextOptions<AT_CsharpContext> options)
            : base(options)
        {
        }

        public DbSet<AT_Csharp.Models.Pintura> Pintura { get; set; } = default!;

        public DbSet<AT_Csharp.Models.Pintores>? Pintores { get; set; }
    }
}
