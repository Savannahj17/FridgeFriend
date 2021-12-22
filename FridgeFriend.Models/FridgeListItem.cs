using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Models
{
    public class FridgeListItem
    {
        public int FridgeId { get; set; }
        public string Nickname { get; set; }
    }
}
