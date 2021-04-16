using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Traking.Site.Models
{
    public abstract class Entity
    {
        [Column("ID_BL")]
        public int Id { get; set; }
    }
}
