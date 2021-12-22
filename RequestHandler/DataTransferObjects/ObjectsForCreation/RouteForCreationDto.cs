using System.ComponentModel.DataAnnotations;

namespace RequestHandler
{
    public class RouteForCreationDto
    {
        [Required(ErrorMessage = "TransportId - required field")]
        public string TransportRegistrationNumber { get; set; }
    }
}
