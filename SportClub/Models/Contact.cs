using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportClub.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Lenght must be between 5 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail is required.")]
        [RegularExpression("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Invalid E-mail.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Subject is required.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Lenght must be between 5 and 150 characters.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; }
    }
}