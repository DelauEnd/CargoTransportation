using System.ComponentModel.DataAnnotations;

namespace CargoTransportation
{
    public class Person
    {
        [Required(ErrorMessage = "Name - required field")]
        [MaxLength(30, ErrorMessage = "Name max length - 30 simbols.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname - required field")]
        [MaxLength(30, ErrorMessage = "Surname max length - 30 simbols.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Patronymic - required field")]
        [MaxLength(30, ErrorMessage = "Patronymic max length - 30 simbols.")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "PhoneNumber - required field")]
        [MaxLength(30, ErrorMessage = "PhoneNumber max length - 16 simbols.")]
        public string PhoneNumber { get; set; }
    }
}
