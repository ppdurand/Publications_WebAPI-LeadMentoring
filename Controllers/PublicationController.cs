using Microsoft.AspNetCore.Mvc;
using publication.Models;
using publication.Repository;
using publication.Service;

namespace publication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublicationController : ControllerBase
{
    private readonly PublicationService _publicationservice;

    public PublicationController(IPublicationRepository publicationrepository)
    {
        _publicationservice = new PublicationService(publicationrepository);
    }

    [HttpGet]
    public IEnumerable<Publication> GetPublication()
    {
        return _publicationservice.GetPublication();
    }

    [HttpPost]
    public string PostPublication([FromBody] Publication publication)
    {
        return _publicationservice.PostPublication(publication);
    }

    [HttpDelete]
    public string DeletePublication([FromBody] int id)
    {
        return _publicationservice.DeletePublication(id);
    }

    [HttpPut]
    public string UpdatePublication([FromBody] int id)
    {
        return _publicationservice.UpdatePublication(id);
    }
}