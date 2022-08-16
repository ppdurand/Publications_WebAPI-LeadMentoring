namespace publication.Repository;

public interface IBaseRepository
{
    IEnumerable<E> Get<E>(E entity) where E : class;
    void Post<E>(E entity) where E : class;
    void Delete<E>(E entity) where E : class;
    void Put<E>(E entity) where E : class;
}