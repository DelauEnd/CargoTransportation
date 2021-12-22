using System.ComponentModel.DataAnnotations;

namespace RequestHandler
{
    public class CategoryForCreationDto
    {
        [Required(ErrorMessage = "Title - required field")]
        [MaxLength(30, ErrorMessage = "Title max length - 30 simbols.")]
        public string Title { get; set; }
    }
}
