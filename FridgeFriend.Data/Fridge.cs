using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Data
{
    public class Fridge
    {


        [Key]
        public int FridgeId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string FridgeMake { get; set; }

        [Required]
        public string FridgeModel { get; set; }

        [Required]
        public string Nickname { get; set; }

        public string Address { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public Guid UserId { get; set; } //not needed?

        [Required]
        public List<RecipeItem> RecipeItems { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
