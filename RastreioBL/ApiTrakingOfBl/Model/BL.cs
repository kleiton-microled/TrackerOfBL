using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrakingOfBl.Model
{
    [Table("TB_BL")]
    public class BL
    {
        [Column("ID_BL")]
        public int Id { get; set; }
        [Column("NR_BL")]
        public string BlNUmber { get; set; }
        [Column("BL_TOKEN")]
        public string BlTOken { get; set; }
        [Column("ID_PARCEIRO_CLIENTE")]
        public int PartnerIdCustomer { get; set; }
       

    }
}
