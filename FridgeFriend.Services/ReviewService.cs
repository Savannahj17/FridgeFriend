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
        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review()
                {
                    RecipeID = model.RecipeID,
                    ReviewID = model.ReviewID,
                    ReviewText = model.ReviewText,
                    Rating = model.Rating,
                    //RecipeName = model.RecipeName,
                    CreatedUtc = DateTimeOffset.Now

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public ReviewDetail GetReviewsByRecipeID(int recipeID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.RecipeID == recipeID);
                return
                    new ReviewDetail
                    {
                        ReviewID = entity.ReviewID,
                        ReviewText = entity.ReviewText
                    };
            }

        }

        public ReviewDetail GetReview(int reviewID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewID == reviewID);
                return
                    new ReviewDetail
                    {
                        ReviewID = entity.ReviewID,
                        ReviewText = entity.ReviewText,
                        Rating = entity.Rating,
                        //RecipeName = entity.RecipeName,
                        CreatedUtc = DateTimeOffset.Now
                    };
            }

        }

        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewID == model.ReviewID);

                entity.ReviewID = model.ReviewID;
                entity.Rating = model.Rating;
                //entity.RecipeName = model.RecipeName;
                entity.ReviewText = model.ReviewText;

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteReview(int ReviewID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewID == ReviewID);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}