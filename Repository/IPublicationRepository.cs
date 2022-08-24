using publication.Enum;
using publication.Models;
using X.PagedList;

namespace publication.Repository;

public interface IPublicationRepository : IBaseRepository
{   
    IPagedList<Publication> Get(
        int pageNumber,
        int pageSize,
        string? search,
        OrderByColumnPublicationEnum orderByColumn,
        OrderByTypeEnum orderByType);

    Task<Publication> GetById(int id);

    Task<Publication> GetByTitle(string title);

}