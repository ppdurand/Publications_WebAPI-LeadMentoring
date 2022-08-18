using publication.Models;

namespace publication.Repository;

public interface IPublicationRepository : IBaseRepository
{
    Publication GetByInitial();
    
    IEnumerable<Publication> Get();

    Publication GetById(int id);

}