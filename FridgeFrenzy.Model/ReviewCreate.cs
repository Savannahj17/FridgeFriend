using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFrenzy.Model
{
    public class ReviewCreate
    {

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least two characters.")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string ReviewText { get; set; }
        public int RecipeID { get; set; }
        public Guid UserID { get; set; }

        public int ReviewID { get; set; }
        public string RecipeName { get; set; }
        public double Rating { get; set; }

        public DateTimeOffset CreatedUtc
        {
            get; set;
        }
    }
}
