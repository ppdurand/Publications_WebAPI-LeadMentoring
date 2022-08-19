using Microsoft.AspNetCore.Mvc;
using publication.Models;
using publication.Repository.Implementation;
using publication.Repository;

namespace publication.Service;

public class PublicationService 
{
    private readonly IPublicationRepository _publicationrepository;

    public PublicationService(IPublicationRepository publicationrepository)
    {
        _publicationrepository = publicationrepository;
    }

    //get

    public IEnumerable<Publication> GetPublication()
    {
        return _publicationrepository.Get();
    }

    // post

    public string PostPublication(Publication publication)
    {
        _publicationrepository.Post(publication);
        return "Publicação criada";
    }

    //delete

    public string DeletePublication(int id)
    {
        Publication publication = _publicationrepository.GetById(id);
        if (publication == null) return "Id inválido";
        _publicationrepository.Delete(publication);
        return "Publicação deletada";
    }

    //update

    public string UpdatePublication(Publication publication)
    {
        _publicationrepository.Put(publication);
        return "Publicação alterada";
    }
}
