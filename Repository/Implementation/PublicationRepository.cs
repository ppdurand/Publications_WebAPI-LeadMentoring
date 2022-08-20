using Microsoft.EntityFrameworkCore;
using publication.Context;
using publication.Models;

namespace publication.Repository.Implementation;

public class PublicationRepository : BaseRepository, IPublicationRepository
{
    private readonly PublicationContext _context;

    public PublicationRepository(PublicationContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<Publication> Get()
    {
        return _context.Publication?.ToList()!;
    }

    public Publication GetById(int id)
    {
        return _context.Publication?.Include(x => x.Comments) .FirstOrDefault(pub => pub.Id == id)!;
    }

}