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

        [Display(Name = "Фото")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Display(Name = "Продукт")]
        [MaxLength(50)]
        public string Products { get; set; }

        [Display(Name = "Описание")]
        [MaxLength(150)]
        public string Description { get; set; }


        [Display(Name = "Вес")]
        [MaxLength(50)]
        public string Weight { get; set; }

        [Display(Name = "Производитель")]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        //[Display(Name = "Знижка")]
        public int DiscountsID { get; set; }

        public virtual Discounts Discounts { get; set; }

    }
}