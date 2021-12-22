using FridgeFriend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Models.RecipeModels
{
    public class RecipeItemEdit
    {
        
            public int ItemID { get; set; }
            public string ItemName { get; set; }
            public FoodGroup Type { get; set; }
    }
}
