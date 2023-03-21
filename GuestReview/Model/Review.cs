using System;
using System.ComponentModel.DataAnnotations;

namespace GuestReview.Model
{
    public class Review
    {
        public Review() 
        {
        }

        public Review(int id, string title, string body, int score)
        {
            Id = id;
            Title = title;
            Body = body;
            Score = score;
        }

        public int Id { get; set; }

        [MaxLength(250)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }

        [Range(1, 5, ErrorMessage = "Please enter a score from 1 to 5")]
        [Required(ErrorMessage = "Score is required")]
        public int Score { get; set; }
    }
}
