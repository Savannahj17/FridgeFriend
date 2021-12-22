using FridgeFriend.Data;
using FridgeFriend.Models;
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

        private readonly ReviewDbContext _context = new ReviewDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> PostReview([FromBody] ReviewCreate model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty");
            }
            if (ModelState.IsValid)
            {
                //_context.Review.Add(review);
                int changeCount = await _context.SaveChangesAsync();
               
                return Ok("You've created your review!");
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Reviews> reviews = await _context.Review.ToListAsync();
            return Ok(reviews);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetReviewByReviewID([FromUri]int reviewID)
        {
            Reviews review = await _context.Review.FindAsync(reviewID);

            if (review != null)
            {
                return Ok(review);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetReviewByRecipeID([FromUri] int recipeID)
        {
            Reviews review = await _context.Review.FindAsync(recipeID);

            if (review != null)
            {
                return Ok(review);
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateReview([FromUri] int reviewID, Reviews updatedReview)
        {
            if(reviewID != updatedReview?.ReviewID)
            {
                return BadRequest("Ids do not match.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Reviews review = await _context.Review.FindAsync(reviewID);

            if (review is null)
                return NotFound();

            review.Rating = updatedReview.Rating;
            review.RecipeName = updatedReview.RecipeName;
            review.Review = updatedReview.Review;

            await _context.SaveChangesAsync();

            return Ok("The review was updated!");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteReview([FromUri]int reviewID)
        {
            Reviews review = await _context.Review.FindAsync(reviewID);

            if (review is null)
                return NotFound();

            _context.Review.Remove(review);

            if(await _context.SaveChangesAsync() == 1)
            {
                return Ok("The restaurant was deleted.");
            }

            return InternalServerError();
        }
    }
}
