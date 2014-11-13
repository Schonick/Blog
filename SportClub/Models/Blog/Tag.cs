using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace SportClub.Models.Blog
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        public string UrlSlug { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }


        public virtual Post Post { get; set; }
    }
}
