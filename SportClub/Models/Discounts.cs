using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportClub.Models
{

    /// <summary>
    ///     Discont.
    /// </summary>
    public class Discounts
    {
        [Key]
        public int DiscountsID { get; set; }

        [Display(Name = "Назва знижки")]
        [MaxLength(50)]
        public string nameDiscount { get; set; }

        [Display(Name = "Розмір знижки")]
        public int discounts { get; set; }

        [Display(Name = "Коментарий")]
        [MaxLength(50)]
        public string Comment { get; set; }

        public virtual ICollection<PhytobarProducts> PhytobarProduct { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }

    }

}