using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportClub.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }

        [Display(Name = "Name")]
        public string NameTicket { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Кількість занять")]
        public int numberOfLesson { get; set; }

        [Display(Name = "Ціна")]
        public decimal Price { get; set; }

        public int SportHallID { get; set; }

        public int DiscountsID { get; set; }

        public virtual ICollection<Accounting> Accounting { get; set; }
        public virtual SportHalls SportHalls { get; set; }
        public virtual Discounts Discounts { get; set; }
    }
}