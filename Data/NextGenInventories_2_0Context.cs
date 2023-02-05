using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NextGenInventories_2._0.Models;

namespace NextGenInventories_2._0.Data
{
    public class NextGenInventories_2_0Context : DbContext
    {
        public NextGenInventories_2_0Context (DbContextOptions<NextGenInventories_2_0Context> options)
            : base(options)
        {
        }

        public DbSet<NextGenInventories_2._0.Models.Measurement> Measurement { get; set; } = default!;

        public DbSet<NextGenInventories_2._0.Models.MeasurementType> MeasurementType { get; set; } = default!;

        public DbSet<NextGenInventories_2._0.Models.Product> Product { get; set; } = default!;

        public DbSet<NextGenInventories_2._0.Models.ProductType> ProductType { get; set; } = default!;

        public DbSet<NextGenInventories_2._0.Models.Users> Users { get; set; } = default!;
    }
}
