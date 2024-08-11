using Review.Domain.Models;

namespace Review.Domain.Services
{
    public interface IReviewService
    {
        Task<List<Models.Review>> GetAllByProductIdAsync(int productId);
        Task<Models.Review?> TryGetById(int id);
        Task TryToDeleteByIdAsync(int id);
        Task CreateAsync(Models.Review review);
    }
}
