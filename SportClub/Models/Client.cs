using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace SportClub.Models
{
    public class Client
    {

        [Key]
        public int ClientID { get; set; }

        [Display(Name = "Фото")]
        [DataType(DataType.ImageUrl)]
        public string foto { get; set; }

        [Display(Name = "Ім'я")]
        [MaxLength(50)]
        public string FName { get; set; }

        [Display(Name = "Прізвище")]
        [MaxLength(50)]
        public string LName { get; set; }

        [Display(Name = "Телефон")]
        public int Phone { get; set; }

        [Display(Name = "Адреса")]
        [MaxLength(150)]
        public string Adress { get; set; }



        [Display(Name = "Дата додання")]
        [DataType(DataType.Date, ErrorMessage = "Введіть дату")]
        public DateTime Data { get; set; }

        [Display(Name = "Активний")]
        public bool activen { get; set; }

        [Display(Name = "Тренеры")]
        public int? TrainerID { get; set; }

        public virtual ICollection<Accounting> Accounting { get; set; }
        public virtual Trainer Trainer { get; set; }

        public virtual ICollection<Visits> Visits { get; set; }
    }
}