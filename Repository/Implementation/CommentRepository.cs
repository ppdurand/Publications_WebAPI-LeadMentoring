using publication.Context;
using publication.Models;

namespace publication.Repository.Implementation;

public class CommentRepository : BaseRepository, ICommentRepository
{
    private readonly PublicationContext _context;
    public CommentRepository(PublicationContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<Comment> Get()
    {
        return _context.Comment?.ToList()!;
    }
}