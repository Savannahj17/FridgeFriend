using FridgeFrenzy.Data;
using FridgeFrenzy.Model;
using FridgeFrenzy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FridgeFrenzy.WebAPI.Controllers
{
    public class ReviewController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IHttpActionResult PostReview(ReviewCreate review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReviewService();

            if (!service.CreateReview(review))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetReviews(int reviewID)
        {
            ReviewService reviewService = CreateReviewService();
            var review = reviewService.GetReview(reviewID);
            return Ok(review);
        }

        [HttpDelete]
        public IHttpActionResult DeleteReview(int reviewID)
        {
            var reviewService = CreateReviewService();

            if (!reviewService.DeleteReview(reviewID))
                return InternalServerError();

            return Ok();
        }

        private ReviewService CreateReviewService()
        {
            var reviewService = new ReviewService();
            return reviewService;
        }
    }
}
