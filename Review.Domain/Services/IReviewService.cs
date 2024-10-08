﻿namespace Review.Domain.Services
{
    public interface IReviewService
    {
        Task<List<Models.Review>> GetAllByProductIdAsync(Guid productId);
        Task<Models.Review?> TryGetById(Guid id);
        Task TryToDeleteByIdAsync(Guid id);
        Task TryToDeleteByUserIdAsync(string userId);
        Task CreateAsync(Models.Review review);
    }
}
