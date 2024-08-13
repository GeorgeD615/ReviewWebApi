﻿namespace ReviewsWebApplication.Models
{
    public class ReviewCreateModelApi
    {
        public string UserId { get; set; }
        public Guid ProductId { get; set; }
        public string? Text { get; set; }
        public int Grade { get; set; }
    }
}
