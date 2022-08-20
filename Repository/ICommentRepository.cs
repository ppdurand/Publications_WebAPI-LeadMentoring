using publication.Models;

namespace publication.Repository;

public interface ICommentRepository : IBaseRepository
{
    IEnumerable<Comment> Get();
}