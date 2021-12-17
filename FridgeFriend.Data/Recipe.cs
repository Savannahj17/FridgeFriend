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
        public int recipeID { get; set; }
        [Required]
        public string recipeName { get; set; }
        [Required]
        public int servingSize { get; set; }
        //[ForeignKey]
        // public int ItemID {get; set; }
        // public virtual Fridge Fridge {get; set; } - nav property 


        public List<Name> NeededItems { get; set; }

        [Required]
        public MealType Type { get; set; }
        public List<Recipe> ListOfRecipes { get; set; }

        [Required]
        public List<Name> AvalibleItems { get; set; }
    }
}
