using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Models.RecipeModels
{
    public class RecipeItemListItem
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        [Display(Name = "Date Expired")]
        public DateTime ExpirationDate { get; set; }
    }
}
