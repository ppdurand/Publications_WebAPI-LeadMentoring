using publication.Models;

namespace publication.Repository;

public interface IPublicationRepository : IBaseRepository
{
    Publication GetByInitial();
}