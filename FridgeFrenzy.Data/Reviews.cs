using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFrenzy.Data
{
    public class Review
    {
        
        [Display(Name = "Recipe")]
        public int RecipeID { get; set; }
        public virtual Recipe RecipeName { get; set; }
        public int ReviewID { get; set; }
        public string ReviewText { get; set; }
        [Range(1, 5, ErrorMessage = "Must enter a number between 1 and 5.")]
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
