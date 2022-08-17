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

    public Publication GetByInitial()
    {
        throw new NotImplementedException();
    }
}