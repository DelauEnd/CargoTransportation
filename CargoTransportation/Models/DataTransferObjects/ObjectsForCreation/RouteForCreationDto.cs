using System.ComponentModel.DataAnnotations;

namespace CargoTransportation
{
    public class RouteForCreationDto
    {
        [Required(ErrorMessage = "TransportId - required field")]
        public string TransportRegistrationNumber { get; set; }
    }
}
