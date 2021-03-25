using System.ComponentModel.DataAnnotations.Schema;

namespace TrakingOfBl.Model
{
    [Table("TB_BL")]
    public class BlTraking
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
