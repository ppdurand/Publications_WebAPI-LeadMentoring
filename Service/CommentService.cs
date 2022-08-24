using System.Security.AccessControl;
using AutoMapper;
using publication.Dto;
using publication.exceptions;
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

    public IEnumerable<CommentDetailsDto> GetComments()
    {
        var result = _commentrepository.Get();
        return _mapper.Map<List<CommentDetailsDto>>(result);
    }

    //post(Dtaetime Errado)
    public string PostComment(CommentCreateDto comment)
    {
        Comment commentDb = _commentrepository.GetByMessage(comment.Menssage!);
        if(commentDb != null) throw new ErrorException((int)StatusCodes.Status400BadRequest, "Este comentário já existe");
        var result = _mapper.Map<Comment>(comment);
        _commentrepository.Post(result);
        return "Comentário Postado";
    }

    public string DeleteComment(int id)
    {
        Comment comment = _commentrepository.GetById(id);
        if(comment == null) return "Id inválida";
        _commentrepository.Delete(comment);
        return "Comentário Deletado";
    }

    //put(Resolver o DTO do update)
    public string UpdateComment(int id, Comment comment)
    {
        if(id != comment.CommentId) return "id inválido";
        _commentrepository.Put(comment);
        return "Comentário alterado";
    }
}