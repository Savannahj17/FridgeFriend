﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Models
{
    public class ReviewListItem
    {
        public int RecipeID { get; set; }
        public int ReviewID { get; set; }
        public string Review { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
