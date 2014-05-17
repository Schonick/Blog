using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportClub.Models
{
    public class PhytobarProducts
    {

        [Key]
        public int PhytobarProductsID { get; set; }

        [Display(Name = "Продукт")]
        public string Products { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }


        [Display(Name = "Вага")]
        public string Weight { get; set; }

        [Display(Name = "Виробник")]
        public string Brand { get; set; }

        [Display(Name = "Ціна")]
        public decimal Price { get; set; }

        public virtual ICollection<Discounts> Discounts { get; set; }

    }
}