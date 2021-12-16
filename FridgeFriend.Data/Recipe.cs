using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeFriend.Data
{
    public enum MealType { Breakfast, Lunch, Dinner, Snack, Dessert, other }
    public class Recipe
    {
        [Key]
        public int recipeID { get; set; }
        [Required]
        public string recipeName { get; set; }
        [Required]
        public int servingSize { get; set; }
        //[ForeignKey]
        // public int ItemID {get; set; }
        // public virtual Fridge Fridge {get; set; } - nav property 

        public List<ItemName> AvalibleItems { get; set; }

        public List<ItemName> NeededItems { get; set; }

        [Required]
        public MealType Type { get; set; }
        public List<Recipes> ListOfRecipes { get; set; }

        [Required]
        public List<ItemName> AvalibleItems { get; set; }
    }
}
