using Microsoft.IdentityModel.Tokens;
using ReviewsWebApplication.Models;

namespace ReviewsWebApplication
{
    public static class MappingHalper
    {
        public static List<ReviewApi?>? ToReviewApiModels (this List<Review.Domain.Models.Review> reviews)
        {
            if (reviews.IsNullOrEmpty())
                return null;

            return reviews.Select(ToReviewApiModel).ToList();
        }

        public static ReviewApi? ToReviewApiModel (this Review.Domain.Models.Review review) 
        {
            if (review == null)
                return null;

            return new ReviewApi()
            {
                Id = review.Id,
                ProductId = review.ProductId,
                UserId = review.UserId,
                Text = review.Text,
                Grade = review.Grade,
                CreateDate = review.CreateDate
            };
        }

        public static Review.Domain.Models.Review? ToReview (this ReviewCreateModelApi reviewCreateModel)
        {
            if(reviewCreateModel == null)
                return null;

            return new Review.Domain.Models.Review()
            {
                ProductId = reviewCreateModel.ProductId,
                UserId = reviewCreateModel.UserId,
                Text = reviewCreateModel.Text,
                Grade = reviewCreateModel.Grade,
                CreateDate = DateTime.Now,
                Status = ReviewStatus.Actual
            };
        }
    }
}
