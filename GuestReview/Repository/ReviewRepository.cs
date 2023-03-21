using GuestReview.Model;
using System.Threading.Tasks;

namespace GuestReview.Repository
{
    public class ReviewRepository
    {
        private readonly ReviewContext _context;

        public ReviewRepository(ReviewContext context)
        {
            _context = context;
        }

        public async Task<Review> Post(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }
    }
}
