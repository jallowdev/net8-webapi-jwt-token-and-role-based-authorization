using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net8_webapi_jwt_token.models.entities;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public string? Author { get; set; }
    
}