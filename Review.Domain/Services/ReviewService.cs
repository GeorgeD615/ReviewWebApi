using Microsoft.EntityFrameworkCore;

namespace Review.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataBaseContext databaseContext;

        public ReviewService(DataBaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task CreateAsync(Models.Review review)
        {
            databaseContext.Reviews.Add(review);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<List<Models.Review>> GetAllByProductIdAsync(Guid productId)
        {
            return await databaseContext.Reviews.
                Where(review => review.ProductId == productId && review.Status == ReviewStatus.Actual).
                ToListAsync();
        }

        public async Task<Models.Review?> TryGetById(Guid id)
        {
            return await databaseContext.Reviews.
                FirstOrDefaultAsync(review => review.Id == id && review.Status == ReviewStatus.Actual);
        }

        public async Task TryToDeleteByIdAsync(Guid id)
        {
            var review = await TryGetById(id);

            if (review == null)
                throw new NullReferenceException($"Отзыв с id = {id} не найден.");

            review.Status = ReviewStatus.Deleted;
            await databaseContext.SaveChangesAsync();
        }

        public async Task TryToDeleteByUserIdAsync(string userId)
        {
            var userReviews = await databaseContext.Reviews.Where(r => r.UserId == userId).ToListAsync(); 
            foreach(var review in userReviews)
            {
                review.Status = ReviewStatus.Deleted;
            }
            await databaseContext.SaveChangesAsync();
        }
    }
}
