using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportClub.Models
{
    public class Ticket
    {
        public Ticket()
        {
            numberOfLesson = 0;
        }
        [Key]
        public int TicketID { get; set; }

        [Display(Name = "Вид абонемента")]
        public string NameTicket { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Кількість занять")]
        public int numberOfLesson { get; set; }

        [Display(Name = "Ціна")]
        public decimal Price { get; set; }

        [Display(Name = "Активна")]
        public bool Activna { get; set; }

        [Display(Name = "Видана")]
        [DataType(DataType.Date, ErrorMessage = "Введіть дату")]
        public DateTime Vudana { get; set; }

        [Display(Name = "Діє до")]
        [DataType(DataType.Date, ErrorMessage = "Введіть дату")]
        public DateTime DeystvueDo { get; set; }

        public int SportHallID { get; set; }

        public int DiscountsID { get; set; }

        public virtual ICollection<Accounting> Accounting { get; set; }
        public virtual SportHalls SportHalls { get; set; }
        public virtual Discounts Discounts { get; set; }
    }
}