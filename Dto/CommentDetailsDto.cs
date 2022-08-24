namespace publication.Dto;

public class CommentDetailsDto
{
    public int CommentId { get; set; }
    public string? Menssage { get; set; }
    public DateTime RegistrationDate { get; set; }
    public int PublicationId { get; set; }
}