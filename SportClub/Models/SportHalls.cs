using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportClub.Models
{
    public class SportHalls
    {
        [Key]
        public int SportHallID { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Display(Name = "Опис")]
        public string Description { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}