using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Data
{
    public class Reviews
    {
        //Foreign
        [Display(Name="Recipe")]
        public virtual int RecipeID { get; set; }

        public int ReviewID { get; set; }
        public string RecipeName { get; set; }
        public string Review { get; set; }
        public double Rating { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public ICollection<Reviews> ListOfReviews { get; set; }

        public Reviews()
        {
            ListOfReviews = new HashSet<Reviews>();
        }
    }
}
