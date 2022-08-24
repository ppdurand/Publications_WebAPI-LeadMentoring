using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using publication.Context;
using publication.Enum;
using publication.Models;
using System.Linq.Dynamic.Core;
using X.PagedList;

namespace publication.Repository.Implementation;

public class PublicationRepository : BaseRepository, IPublicationRepository
{
    private readonly PublicationContext _context;

    public PublicationRepository(PublicationContext context) : base(context)
    {
        _context = context;
    }

    public IPagedList<Publication> Get(
        int pageNumber,
        int pageSize,
        string? search,
        OrderByColumnPublicationEnum orderByColumn,
        OrderByTypeEnum orderByType)
    {
        return _context.Publication?.OrderBy($"{orderByColumn.ToString()} {orderByType.ToString()}").Where(n => n.Title!.Contains(search!)).ToPagedList(pageNumber, pageSize)!;
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