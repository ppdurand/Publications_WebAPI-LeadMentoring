using publication.Models;

namespace publication.Repository;

public interface IPublicationRepository : IBaseRepository
{   
    IEnumerable<Publication> Get();

    Publication GetById(int id);

}