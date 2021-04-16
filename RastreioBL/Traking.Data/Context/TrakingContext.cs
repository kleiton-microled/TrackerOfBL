using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Traking.Business.Models;

namespace Traking.Data.Context
{
    public class TrakingContext : DbContext
    {
        public TrakingContext(DbContextOptions options) :base(options)
        {

        }

        public DbSet<BL> Bls { get; set; }
    }
}
