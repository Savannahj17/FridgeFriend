using FridgeFriend.Data;
using FridgeFriend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeFriend.Services
{
    public class ReviewService
    {
        public bool CreateReview(ReviewCreate model, int RecipeID)
        {
            var entity =
                new Review()
                {
                   
                    CreatedUtc = DateTimeOffset.Now

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Review.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<ReviewListItem> GetAllReviews(int RecipeID)
        {
            using (var ctx = new ApplicationDbContext())
            {//linq sintax
                var query =
                    ctx //database
                    . //table
                    .Select(
                        else => new ReviewListItem //define the form
                        {
                            ReviewID = e.ReviewID

                        });
                return query.ToArray();
            }

        }

        public bool GetReview(int ReviewID)
        { using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        .Where(e = e.ReviewID)
            }
        
        }

        public bool UpdateReview(int ReviewID)
        {

        }

        public bool DeleteReview(ReviewID)
        {

        }
    }
}
