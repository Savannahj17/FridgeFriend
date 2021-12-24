using FridgeFrenzy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFrenzy.Model
{
    public class RecipeCreate
    {
        [Required]
        public int RecipeID { get; set; }
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        [MaxLength(25, ErrorMessage = "Too many characters. Max is 25.")]
        [Required]
        public string RecipeName { get; set; }
        [Required]
        public int ServingSize { get; set; }
        [Required]
        public string RecipeText { get; set; }
        [Required]
        public List<RecipeItem> Items { get; set; }
        [Required]
        [Display(Name = "Meal Type")]
        public MealType Type { get; set; }
        [Required]
        public RecipeItem ItemName { get; set; }

    }
}
