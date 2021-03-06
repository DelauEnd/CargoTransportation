using System;
using System.ComponentModel.DataAnnotations;

namespace CargoTransportation
{
    public class TransportForCreationDto
    {
        [Required(ErrorMessage = "RegistrationNumber - required field")]
        [MaxLength(30, ErrorMessage = "RegistrationNumber max length - 30 simbols.")]
        public string RegistrationNumber { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "LoadCapacity - required field and can not be less then 0")]
        public double LoadCapacity { get; set; }

        [Required(ErrorMessage = "Driver info - required fields")]
        public Person Driver { get; set; }
    }
}
