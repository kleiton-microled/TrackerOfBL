using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrakingOfBl.Model.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }
        public SqlContext(DbContextOptions<SqlContext> options) :base(options)
        {

        }
        public DbSet<BlTraking> blTrakings { get; set; }
    }
}
