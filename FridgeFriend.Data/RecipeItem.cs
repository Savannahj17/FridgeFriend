using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Data
{
    public enum FoodGroup { grain, fruit, vegetable, dairy, meat, eggs, fats, sweets, beverages, other }
    public class RecipeItem
    {
        [Key]
        public int ItemID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Calories { get; set; }
        //[ForeignKey]
        // public int FridgeID {get; set; }
        // public virtual Fridge Fridge {get; set; } - nav property 
        [Required]
        [Display(Name = "Date Purchased")]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [Display(Name = "Date Expired")]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public FoodGroup Type { get; set; }
       // public ICollection<Recipes> ListOfRecipes { get; set; }
       //public Recipe()
       //{
       //   ListOfRecipes = new HashSet<Recipe>();
       // 
    }
}
