using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Models
{
    public class ReviewEdit
    {
        public int ReviewID { get; set; }
        public int RecipeID { get; set; }
        public string ReviewText { get; set; }
        public string RecipeName { get; set; }
        public int Rating { get; set; }
    }
}
