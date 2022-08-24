using System.ComponentModel.DataAnnotations;

namespace publication.Dto;

public class PublicationCreateDto
{
    [Required(ErrorMessage = "Nome da publicação é obrigatório")]
    [MinLength(length: 5, ErrorMessage = "O nome da publicação deve ter no mínimo 5 caracteres")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "O corpo da publicação é obrigatório")]
    [MinLength(length: 20, ErrorMessage = "O corpo da publicação deve ter no mínimo 20mcaracteres")]
    public string? Message { get; set; }
    [Required(ErrorMessage = "Informe o máximo de comentários que a publicação poderá possuir")]
    public int MaxComments { get; set; }
}