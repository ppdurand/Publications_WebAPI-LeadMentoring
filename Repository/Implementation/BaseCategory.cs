using publication.Context;
using publication.Repository;

namespace publication.Repository.Implementation;

public class BaseRepository : IBaseRepository
{
    private readonly PublicationContext _context;

    public BaseRepository(PublicationContext context)
    {
        _context = context;
    }

    public void Delete<E>(E entity) where E : class
    {
        throw new NotImplementedException();
    }

    public IEnumerable<E> Get<E>(E entity) where E : class
    {
        throw new NotImplementedException();
    }

    public void Post<E>(E entity) where E : class
    {
        _context.Add<E>(entity);
        SaveChanges();
    }

    public void Put<E>(E entity) where E : class
    {
        throw new NotImplementedException();
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }
}

