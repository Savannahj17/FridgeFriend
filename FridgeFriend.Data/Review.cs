using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Data
{
    public class Review
    {
        //[ForeignKey]
        public int RecipeID { get; set; }

        public int ReviewID { get; set; }
        public string RecipeName { get; set; }
       // public string Review { get; set; }
        public double Rating { get; set; }
        public ICollection<Review> ListOfReviews { get; set; }
    }
}
