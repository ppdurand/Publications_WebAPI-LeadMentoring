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

    // public IEnumerable<Publication> GetPublications()
    // {
        
    // }

    // post

    public string PostPublication(Publication publication)
    {
        _publicationrepository.Post(publication);
        return "Publicação criada";
    }
}
