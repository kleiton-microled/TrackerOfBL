using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrakingSite.ViewModels
{
    public class BlViewModel
    {
        [Required(ErrorMessage = "Numero da Bl obrigatorio")]
        [DisplayName("Numero da Bl")]
        public string NumeroBl { get; set; }
        public string TrakingJson { get; set; }
    }
}
