using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFrenzy.Model
{
    public class FridgeCreate
    {
        [Required]
        //[Display(ErrorMessage="")]
        public int FridgeId { get; set; }
        public string FridgeMake { get; set; }

        [Required]
        public string FridgeModel { get; set; }

        [Required]
        public string Nickname { get; set; }

        public string Address { get; set; }

        [Required]
        public string UserEmail { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
    }
}
