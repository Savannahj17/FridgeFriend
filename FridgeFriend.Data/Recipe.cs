using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FridgeFriend.Data
{
    public enum MealType { Breakfast, Lunch, Dinner, Snack, Dessert, other }
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }
        [Required]
        public string RecipeName { get; set; }
        [Required]
        public int ServingSize { get; set; }
        [ForeignKey(nameof(ItemName))]
        public int ItemId { get; set; }
        public virtual RecipeItem ItemName { get; set; }
        public List<RecipeItem> NeededItems { get; set; }
        [Required]
        public List<RecipeItem> AvailableItems { get; set; }

        [Required]
        [Display(Name = "MealType")]
        public MealType Type { get; set; }
        public List<Recipe> ListOfRecipes { get; set; }
        public ICollection<RecipeItem> RecipeItems { get; set; }


    }
}
