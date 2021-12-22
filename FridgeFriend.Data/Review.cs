using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Data
{
    public class Review
    {
        //Foreign
        [Display(Name="Recipe")]
        public virtual int RecipeID { get; set; }

        public int ReviewID { get; set; }
        public string RecipeName { get; set; }
        public string ReviewText { get; set; }
        public double Rating { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public ICollection<Review> ListOfReviews { get; set; }

        public Review()
        {
            ListOfReviews = new HashSet<Review>();
        }
    }
}
