using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFrenzy.Data
{
    public enum FoodGroup { grain, fruit, vegetable, dairy, meat, eggs, fats, sweets, beverages, other }
    public class RecipeItem
    {
        [Key]
        public int ItemID { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int Calories { get; set; }
        [ForeignKey(nameof(Fridge))]
        public int FridgeId { get; set; }
        public virtual Fridge Fridge { get; set; }
        [Required]
        [Display(Name = "Date Purchased")]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [Display(Name = "Date Expired")]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public FoodGroup FoodType { get; set; }
        public virtual ICollection<Recipe> ListOfRecipes { get; set; }
        public RecipeItem()
        {
            ListOfRecipes = new HashSet<Recipe>();

        }
    }
}
