using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportClub.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Введите имя.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длина должна быть от 5 до 50 символов.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите E-mail.")]
        [RegularExpression("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Invalid E-mail.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Тема сообщения обязательна.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Длина должна быть от 5 до 150 символов.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Введите текст сообщения.")]
        public string Message { get; set; }
    }
}