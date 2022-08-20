using System.Security.AccessControl;
using AutoMapper;
using publication.Dto;
using publication.Models;
using publication.Repository;

namespace publication.Service;

public class CommentService
{
    private readonly ICommentRepository _commentrepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentrepository, IMapper mapper)
    {
        _commentrepository = commentrepository;
        _mapper = mapper;
    }

    public IEnumerable<CommentDto> GetComments()
    {
        var result = _commentrepository.Get();
        return _mapper.Map<List<CommentDto>>(result);
    }

    public string PostComment(Comment comment)
    {
        _commentrepository.Post(comment);
        return "Comentário Postado";
    }

    public string DeleteComment(int id)
    {
        Comment comment = _commentrepository.GetById(id);
        if(comment == null) return "Id inválida";
        _commentrepository.Delete(comment);
        return "Comentário Deletado";
    }

    public string UpdateComment(int id, Comment comment)
    {
        if(id != comment.CommentId) return "id inválido";
        _commentrepository.Put(comment);
        return "Comentário alterado";
    }
}