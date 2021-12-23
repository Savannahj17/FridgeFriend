using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFrenzy.Model
{
    public class FridgeDetail
    {
        public int FridgeId { get; set; }
        public string FridgeMake { get; set; }
        public string FridgeModel { get; set; }
        public string Nickname { get; set; }
        public string Address { get; set; }
        public string UserEmail { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
