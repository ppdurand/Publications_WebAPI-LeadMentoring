using publication.Models;

namespace publication.Repository;

public interface IPublicationRepository : IBaseRepository
{   
    Task<IEnumerable<Publication>> Get();

    Task<Publication> GetById(int id);

    Task<Publication> GetByTitle(string title);

}