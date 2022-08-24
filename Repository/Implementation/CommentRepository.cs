using System.Net.Mail;
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

    public Comment GetById(int id)
    {
        return _context.Comment?.FirstOrDefault(com => com.CommentId == id)!;
    }

    public Comment GetByMessage(string menssage)
    {
        return _context.Comment?.FirstOrDefault(msg => msg.Menssage == menssage)!;
    }
}