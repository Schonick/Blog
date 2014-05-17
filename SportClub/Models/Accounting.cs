using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportClub.Models
{
    public class Accounting
    {
        public int AccountingID { get; set; }
        public int ClientID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Місяць")]
        public DateTime Month { get; set; }

        [Display(Name = "Оплата")]
        public decimal Payment { get; set; }

        public int TicketID { get; set; }

        public virtual Client Client { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual Discounts Discounts { get; set; }

    }
}