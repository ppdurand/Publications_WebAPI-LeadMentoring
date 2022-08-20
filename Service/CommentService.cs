using System.Security.AccessControl;
using publication.Models;
using publication.Repository;

namespace publication.Service;

public class CommentService
{
    private readonly ICommentRepository _commentrepository;

    public CommentService(ICommentRepository commentrepository)
    {
        _commentrepository = commentrepository;
    }

    public IEnumerable<Comment> GetComments()
    {
        return _commentrepository.Get();
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

    public string UpdateComment(Comment comment)
    {
        _commentrepository.Put(comment);
        return "Comentário alterado";
    }
}