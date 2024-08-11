namespace ReviewsWebApplication.Models
{
    public class ReviewCreateModelApi
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string? Text { get; set; }
        public int Grade { get; set; }
    }
}
