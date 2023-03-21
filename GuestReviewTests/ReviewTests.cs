using GuestReview.Model;
using GuestReview.Repository;
using GuestReview.Validator;
using Xunit;

namespace GuestReviewTests
{
    public class ReviewTests : BaseTest
    {
        //[Fact]
        //public void PostValidReview()
        //{
        //    Review review = new()
        //    {
        //        Title = "test title",
        //        Body = "test body",
        //        Score = 1
        //    };

        //    context.User.Add(user);
        //    context.SaveChanges();

        //    Assert.Equal(1, result.Id);
        //}

        [Fact]
        public void PostValidReview()
        {
            var title = "test title";
            var body = "test body";
            var score = 1;

            ReviewRepository repo = new(context);
            Review review = new()
            {
                Title = title,
                Body = body,
                Score = score
            };

            var result = repo.Post(review).Result;

            Assert.Equal(1, result.Id);
            Assert.Equal(title, result.Title);
            Assert.Equal(body, result.Body);
            Assert.Equal(score, result.Score);
        }

        //[Theory]
        //[InlineData("")]
        //public void PostInvalidReview_TitleEmpty(string title)
        //{
        //    Review review = new()
        //    {
        //        Title = title,
        //        Body = "test body",
        //        Score = 1
        //    };

        //    Assert.Null(review.Title);
        //    Assert.Empty(review.Title);
        //}

        [Theory]
        [InlineData("")]
        public void PostInvalidReview_TitleEmpty(string title)
        {
            Review review = new()
            {
                Title = title,
                Body = "test body",
                Score = 1
            };

            var val = new ReviewValidator().Validate(review);
            Assert.False(val.IsValid);
        }

        [Theory]
        [InlineData("")]
        public void PostInvalidReview_BodyEmpty(string body)
        {
            Review review = new()
            {
                Title = "test title",
                Body = body,
                Score = 1
            };

            var val = new ReviewValidator().Validate(review);
            Assert.False(val.IsValid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public void PostInvalidReview_ScoreOutOfRange(int score)
        {
            Review review = new()
            {
                Title = "test title",
                Body = "test body",
                Score = score
            };

            var val = new ReviewValidator().Validate(review);
            Assert.False(val.IsValid);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        public void PostValidReview_ScoreInRange(int score)
        {
            Review review = new()
            {
                Title = "test title",
                Body = "test body",
                Score = score
            };

            var val = new ReviewValidator().Validate(review);
            Assert.True(val.IsValid);
        }
    }
}
