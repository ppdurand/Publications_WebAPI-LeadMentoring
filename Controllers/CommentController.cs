using System.Net;
using Microsoft.AspNetCore.Mvc;
using publication.Repository;
using publication.Service;
using publication.Models;

namespace publication.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CommentController : ControllerBase
{
    private readonly CommentService _commentservice;
    public CommentController(ICommentRepository commentrepository)
    {
        _commentservice = new CommentService(commentrepository);
    }

    [HttpGet]
    public IEnumerable<Comment> ListComment()
    {
        return _commentservice.GetComments();
    }

    [HttpPost]
    public string CreateComment([FromBody] Comment comment)
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