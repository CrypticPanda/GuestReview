using GuestReview.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GuestReviewTests
{
    public class BaseTest
    {
        protected ReviewContext context;

        public BaseTest(ReviewContext context = null)
        {
            this.context = context ?? GetInMemoryDBContext();
        }

        protected static ReviewContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ReviewContext>();
            var options = builder.UseInMemoryDatabase("Review")
                .UseInternalServiceProvider(serviceProvider).Options;

            ReviewContext dbContext = new(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
