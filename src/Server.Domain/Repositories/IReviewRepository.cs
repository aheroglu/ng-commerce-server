using Server.Domain.Entities;

namespace Server.Domain.Repositories;

public interface IReviewQueryRepository : IQueryRepository<Review>
{
    Task<bool> IsReviewExistsAsync(string appUserId, string productId, CancellationToken cancellationToken = default);
}

public interface IReviewCommandRepository : ICommandRepository<Review> { }