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
        public async Task<List<Models.Review>> GetAllByProductIdAsync(int productId)
        {
            return await databaseContext.Reviews.
                Where(review => review.ProductId == productId && review.Status == ReviewStatus.Actual).
                ToListAsync();
        }

        public async Task<Models.Review?> TryGetById(int id)
        {
            return await databaseContext.Reviews.
                FirstOrDefaultAsync(review => review.Id == id && review.Status == ReviewStatus.Actual);
        }

        public async Task TryToDeleteByIdAsync(int id)
        {
            var review = await TryGetById(id);

            if (review == null)
                throw new NullReferenceException($"Отзыв с id = {id} не найден.");

            review.Status = ReviewStatus.Deleted;
            await databaseContext.SaveChangesAsync();
        }
    }
}
