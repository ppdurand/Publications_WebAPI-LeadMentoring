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

    [HttpPost]
    public string PostPublication([FromBody] Publication publication)
    {
        return _publicationservice.PostPublication(publication);
    }
}