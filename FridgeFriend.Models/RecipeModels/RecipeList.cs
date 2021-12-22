using FridgeFriend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Models.RecipeModels
{
    public class RecipeList
    {
        public int RecipeId { get; }
        public string RecipeName { get; }
        public MealType Type { get; }
        public int ItemId { get; }
    }
}
