using FridgeFrenzy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFrenzy.Model
{
    public class RecipeEdit
    {
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public int ServingSize { get; set; }
        public List<RecipeItem> NeededItems { get; set; }
        public MealType Type { get; set; }
        public int ItemId { get; set; }
    }
}
