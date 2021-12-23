using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFrenzy.Data
{
    public enum MealType { Breakfast, Lunch, Dinner, Snack, Dessert, other }
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }

        public string RecipeName { get; set; }

        public int ServingSize { get; set; }
        public string RecipeText { get; set; }

        [ForeignKey("ItemID")]
        public int RecipeItemID { get; set; }

        [Display(Name = "MealType")]
        public MealType Type { get; set; }
        //public List<Recipe> ListOfRecipes { get; set; }
        public virtual ICollection<RecipeItem> ListRecipeItems { get; set; }
        public Recipe()
        {
            ListRecipeItems = new HashSet<RecipeItem>();
        }


    }
}
