﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Models
{
    public class ReviewCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least two characters.")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string Review { get; set; }

        public DateTimeOffset MyProperty { get; set; }
    }
}
