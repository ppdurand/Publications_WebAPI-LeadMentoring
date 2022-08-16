namespace publication.Models;

public class Publication
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }
    public DateTime CreationDate { get; set; }
    public int MaxComments { get; set; }    
}