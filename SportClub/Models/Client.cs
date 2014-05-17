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

        [Display(Name = "Ім'я")]
        public string FName { get; set; }

        [Display(Name = "Прізвище")]
        public string LName { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        public int TrainerID { get; set; }

        public virtual ICollection<Accounting> Accounting { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}