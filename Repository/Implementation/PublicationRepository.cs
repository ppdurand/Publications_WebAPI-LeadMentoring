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

    public async Task<IEnumerable<Publication>> Get()
    {
        return await _context.Publication?.ToListAsync()!;
    }

    public async Task<Publication> GetById(int id)
    {
        return await _context.Publication?.Include(x => x.Comments).FirstOrDefaultAsync(pub => pub.Id == id)!;
    }

    public async Task<Publication> GetByTitle(string title)
    {
        return await _context.Publication?.FirstOrDefaultAsync(t => t.Title == title)!;
    }
}