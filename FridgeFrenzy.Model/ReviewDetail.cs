using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFrenzy.Model
{
    public class ReviewDetail
    {
        public Guid UserId { get; set; }
        public int ReviewID { get; set; }
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public string ReviewText { get; set; }
        [Required]
        public double Rating { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
