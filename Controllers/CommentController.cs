using System.Net;
using Microsoft.AspNetCore.Mvc;
using publication.Repository;
using publication.Service;
using publication.Models;
using AutoMapper;
using publication.Dto;

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
    public string CreateComment([FromBody] CommentCreateDto comment)
    {
        return _commentservice.PostComment(comment);
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