namespace publication.Models;

public class Comment
{
    public int CommentId { get; set; }
    public string? Menssage { get; set; }
    public DateTime RegistrationDate { get; set; }
    public int PublicationId { get; set; }
    public Publication? Publication { get; set; }
}