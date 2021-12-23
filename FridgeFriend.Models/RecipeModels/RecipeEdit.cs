using FridgeFriend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Models.RecipeModels
{
    public class RecipeEdit
    {
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public int ServingSize { get; set; }
        public string RecipeText { get; set; }
        public MealType Type { get; set; }
        public int ItemId { get; set; }
    }
}
