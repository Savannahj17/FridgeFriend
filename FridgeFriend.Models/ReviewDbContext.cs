using FridgeFriend.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Models
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext() : base("DefaultConnection")
        {

        }


        public DbSet<Reviews> Review { get; set; }
    }
}
