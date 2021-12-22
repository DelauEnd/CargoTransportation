﻿using System.ComponentModel.DataAnnotations;

namespace RequestHandler
{
    public class CustomerForCreation
    {
        [Required(ErrorMessage = "Address - required field")]
        [MaxLength(30, ErrorMessage = "RegistrationNumber max length - 30 simbols.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "ContactPerson - required fields")]
        public Person ContactPerson { get; set; }
    }
}
