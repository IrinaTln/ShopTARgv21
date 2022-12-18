﻿using Microsoft.EntityFrameworkCore;
using ShopTARgv21.Core.Domain;
using ShopTARgv21.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv21.Data
{
  
        public class ShopDbContext : DbContext
        {
            public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }
            public DbSet<Spaceship> Spaceship { get; set; }

            public DbSet<Car> Car { get; set; }

        }
    
}
