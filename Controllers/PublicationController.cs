using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using publication.Dto;
using publication.exceptions;
using publication.Models;
using publication.Repository;
using publication.Service;

namespace publication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublicationController : ControllerBase
{
    private readonly PublicationService _publicationservice;

    public PublicationController(IPublicationRepository publicationrepository, IMapper mapper)
    {
        _publicationservice = new PublicationService(publicationrepository, mapper);
    }

    [HttpGet]
    public IEnumerable<PublicationDto> GetPublication()
    {
        return _publicationservice.GetPublication();
    }

    [HttpPost]
    public ActionResult<string> PostPublication([FromBody] PublicationCreateDto publication)
    {
        try
        {
            return _publicationservice.PostPublication(publication);
        }
        catch(ErrorException ex)
        {
            return StatusCode(ex.StatusCode, ex); 
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Tivemos um problema, tente nvoamente mais tarde");
        }
    }

    [HttpDelete]
    public string DeletePublication([FromBody] int id)
    {
        return _publicationservice.DeletePublication(id);
    }

    [HttpPut("{id:int}")]
    public string UpdatePublication(int id, [FromBody] Publication publication)
    {
        return _publicationservice.UpdatePublication(id, publication);
    }

    [HttpGet("{id:int}")]
    public PublicationDetailsDto DetailsPublication(int id)
    {
        return _publicationservice.DetailsPublication(id);
    }
}