using System.ComponentModel.DataAnnotations;

namespace Merchandise.Models
{
    public record ProductCreationModel
    (
        string Name,

        [Range(1, int.MaxValue, ErrorMessage = "Incorrect price")]
        int Price,
        
        string? Description,
        
        [Range(1, int.MaxValue, ErrorMessage = "Incorrect products number")]
        int? Number
    );
}
