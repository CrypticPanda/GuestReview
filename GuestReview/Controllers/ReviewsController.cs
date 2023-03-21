using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuestReview.Model;
using GuestReview.Repository;

namespace GuestReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewContext _context;
        private readonly ReviewRepository _repository;
        
        public ReviewsController(ReviewContext context)
        {
            _context = context;
            _repository = new ReviewRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            if (ModelState.IsValid)
            {
                if (review.Score >= 4)
                {
                    //ToDo: External Api
                }

               return await _repository.Post(review);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
