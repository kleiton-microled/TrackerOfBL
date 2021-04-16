using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Traking.Site.Models
{
    [Table("TB_BL")]
    public class BL : Entity
    {
        [Column("NR_BL")]
        public string BlNumber { get; set; }
        [Column("BL_TOKEN")]
        public string BlToken { get; set; }
        [Column("TRAKING_BL")]
        public string JsonRastreio { get; set; }
        public BL()
        {

        }
        

    }
   


}
