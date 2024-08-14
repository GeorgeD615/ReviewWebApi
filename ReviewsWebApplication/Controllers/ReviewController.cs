using Microsoft.AspNetCore.Mvc;
using Review.Domain.Services;
using ReviewsWebApplication.Models;

namespace ReviewsWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> logger;
        private readonly IReviewService reviewService;

        public ReviewController(ILogger<ReviewController> logger, IReviewService reviewService)
        {
            this.logger = logger;
            this.reviewService = reviewService;
        }

        [HttpGet("GetByProductId")]
        public async Task<ActionResult<List<Review.Domain.Models.Review>>> GetByProductId(Guid productId)
        {
            try
            {
                var result = await reviewService.GetAllByProductIdAsync(productId);
                return Ok(result.ToReviewApiModels());
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<ReviewApi>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await reviewService.TryGetById(id);
                return Ok(result.ToReviewApiModel());
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateAsync(ReviewCreateModelApi reviewCreateModel)
        {
            try
            {
                var review = reviewCreateModel.ToReview();
                await reviewService.CreateAsync(review);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        //[Authorize]
        [HttpDelete("DeleteById")]
        public async Task<ActionResult> DeleteByIdAsync(Guid id)
        {
            try
            {
                await reviewService.TryToDeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpDelete("DeleteByUserId")]
        public async Task<ActionResult> DeleteByUserIdAsync(string userId)
        {
            try
            {
                await reviewService.TryToDeleteByUserIdAsync(userId);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}