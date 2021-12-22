using FridgeFriend.Data;
using FridgeFriend.Models;
using FridgeFriend.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FridgeFriend.WebApi.Controllers
{
    public class ReviewController : ApiController
    {

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult PostReview([FromBody] ReviewCreate review)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReviewService();

            if (!service.CreateReview(review))
                return InternalServerError();

            return Ok();

        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Review> reviews = await _context.Reviews.ToListAsync();
            return Ok(reviews);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetReviewByReviewID([FromUri] int reviewID)
        {
            Review review = await _context.Reviews.FindAsync(reviewID);

            if (review != null)
            {
                return Ok(review);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetReviewByRecipeID([FromUri] int recipeID)
        {
            Review review = await _context.Reviews.FindAsync(recipeID);

            if (review != null)
            {
                return Ok(review);
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateReview([FromUri] int reviewID, Review updatedReview)
        {
            if (reviewID != updatedReview?.ReviewID)
            {
                return BadRequest("Ids do not match.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Review review = await _context.Reviews.FindAsync(reviewID);

            if (review is null)
                return NotFound();

            review.Rating = updatedReview.Rating;
            review.RecipeName = updatedReview.RecipeName;
            review.ReviewText = updatedReview.ReviewText;

            await _context.SaveChangesAsync();

            return Ok("The review was updated!");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteReview([FromUri] int reviewID)
        {
            Review review = await _context.Reviews.FindAsync(reviewID);

            if (review is null)
                return NotFound();

            _context.Reviews.Remove(review);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The restaurant was deleted.");
            }

            return InternalServerError();
        }

        private ReviewService CreateReviewService()
        {
            var reviewService = new ReviewService();
            return reviewService;
        }
    }
}
