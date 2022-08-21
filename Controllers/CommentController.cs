using System.Net;
using Microsoft.AspNetCore.Mvc;
using publication.Repository;
using publication.Service;
using publication.Models;
using AutoMapper;
using publication.Dto;
using publication.exceptions;

namespace publication.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CommentController : ControllerBase
{
    private readonly CommentService _commentservice;
    public CommentController(ICommentRepository commentrepository, IMapper mapper)
    {
        _commentservice = new CommentService(commentrepository, mapper);
    }

    [HttpGet]
    public IEnumerable<CommentDetailsDto> ListComment()
    {
        return _commentservice.GetComments();
    }

    [HttpPost]
    public ActionResult<string> CreateComment([FromBody] CommentCreateDto comment)
    {
        try
        {
            return _commentservice.PostComment(comment);
     
        }
        catch (ErrorException ex)
        {
            return StatusCode(ex.StatusCode, ex);
        }
        catch(Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Houve um problema na criação do seu comentário, por favor tente mais tarde");
        }
    }

    [HttpDelete("{id:int}")]
    public string DeleteComment(int id)
    {
        return _commentservice.DeleteComment(id);
    }

    [HttpPut("{id:int}")]
    public string UpdateComment(int id, [FromBody] Comment comment)
    {
        return _commentservice.UpdateComment(id, comment);
    }
}