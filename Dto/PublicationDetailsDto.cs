using publication.Models;

namespace publication.Dto;

public class PublicationDetailsDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }
    public DateTime CreationDate { get; set; }
    public List<CommentDto>? Comments { get; set; }  
}