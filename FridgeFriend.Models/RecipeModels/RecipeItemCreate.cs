using FridgeFriend.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Models.RecipeModels
{
    public class RecipeItemCreate
    {
        public int ItemID { get; set; }
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        [MaxLength(25, ErrorMessage = "Too many characters. Max is 25.")]
        [Required]
        public string Name { get; set; }
        [Required]
        public int Calories { get; set; }
        [Required]
        [Display(Name = "Date Purchased")]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [Display(Name = "Date Expired")]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public FoodGroup Type { get; set; }
        public int FridgeId { get; set; }
    }
}
