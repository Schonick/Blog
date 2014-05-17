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
        public int DiscountsID { get; set; }
        
        [Display(Name = "Discont")]
        public int? discounts { get; set; }

        public int PhytobarProductsID { get; set; }

  

        public virtual PhytobarProducts PhytobarProduct { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }

    }

}