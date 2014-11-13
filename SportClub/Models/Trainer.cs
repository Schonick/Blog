using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportClub.Models
{
    public class Trainer
    {
      
        [Key]
        public int TrainerID { get; set; }

        [Display(Name = "Фото")]
        [DataType(DataType.ImageUrl,ErrorMessage = "Додайте фото")]
        public string Image { get; set; }

        [Display(Name = "Имя")]
        public string FName { get; set; }

        [Display(Name = "Фамилия")]
        public string LName { get; set; }

        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }

        //[Display(Name = "Зарплата")]       
        //public decimal Salary { get; set; }

        [Display(Name = "Краткая информация")]
        public string Description { get; set; }

       
        [Display(Name = "Дата добавления")]
        [DataType(DataType.Date, ErrorMessage = "Введите дату")]
        public DateTime Data { get; set; }


        public virtual ICollection<Client> Client { get; set; }
    }
}