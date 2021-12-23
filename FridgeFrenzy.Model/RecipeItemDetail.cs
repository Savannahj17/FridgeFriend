using FridgeFrenzy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFrenzy.Model
{
    public class RecipeItemDetail
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        [Display(Name = "Calories")]
        public int Calories { get; set; }
        [Display(Name = "Date Purchased")]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Date Expired")]
        public DateTime ExpirationDate { get; set; }
        [Display(Name = "Food Type")]
        public FoodGroup FoodType { get; set; }
    }
}
