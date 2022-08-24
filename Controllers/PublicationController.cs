using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using publication.Dto;
using publication.exceptions;
using publication.Models;
using publication.Repository;
using publication.Service;
using publication.Enum;

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
    public IEnumerable<PublicationDto> GetPublication(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 5,
        [FromQuery] string? search = "",
        [FromQuery] OrderByColumnPublicationEnum orderByColumn = OrderByColumnPublicationEnum.Id,
        [FromQuery] OrderByTypeEnum orderByType = OrderByTypeEnum.ASC
    )
    {
        return _publicationservice.GetPublication(pageNumber, pageSize, search, orderByColumn, orderByType);
    }

    [HttpPost]
    public async Task<ActionResult<string>> PostPublication([FromBody] PublicationCreateDto publication)
    {
        try
        {
            return await _publicationservice.PostPublication(publication);
        }
        catch(ErrorException ex)
        {
            return StatusCode(ex.StatusCode, ex.Message); 
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Tivemos um problema, tente nvoamente mais tarde");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<string> DeletePublication(int id)
    {
        return await _publicationservice.DeletePublication(id);
    }

    [HttpPut("{id:int}")]
    public  ActionResult<string> UpdatePublication(int id, [FromBody] PublicationDto publication)
    {
        return _publicationservice.UpdatePublication(id, publication);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PublicationDetailsDto>> DetailsPublicationAsync(int id)
    {
        var result = await _publicationservice.DetailsPublication(id);
        return new OkObjectResult(result);
    }
}