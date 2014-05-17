using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportClub.Models
{
    public class Trainer
    {

        public int TrainerID { get; set; }

        [Display(Name = "Ім'я")]
        public string FName { get; set; }

        [Display(Name = "Прізвище")]
        public string LName { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Зарплата")]
        public decimal Salary { get; set; }


        public virtual ICollection<Client> Client { get; set; }
    }
}