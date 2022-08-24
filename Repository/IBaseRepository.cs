namespace publication.Repository;

public interface IBaseRepository
{
    void Post<E>(E entity) where E : class;
    void Delete<E>(E entity) where E : class;
    void Put<E>(E entity) where E : class;
    bool SaveChanges();
}