using publication.Models;

namespace publication.Repository;

public interface ICommentRepository : IBaseRepository
{
    IEnumerable<Comment> Get();

    Comment GetById(int id);
    Comment GetByMessage(string menssage);
}