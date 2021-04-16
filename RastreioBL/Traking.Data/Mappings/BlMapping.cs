using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Traking.Business.Models;

namespace Traking.Data.Mappings
{
    public class BlMapping : IEntityTypeConfiguration<BL>
    {
        public void Configure(EntityTypeBuilder<BL> builder)
        {
           
        }
    }
}
