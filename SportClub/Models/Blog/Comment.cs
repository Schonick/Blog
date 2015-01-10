using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using WebMatrix.WebData;

namespace SportClub.Models.Blog
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Время создания")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Имя Автора")]
        public string Author { get; set; }

        [Display(Name = "Контент")]
        public string Content { get; set; }

        public virtual Post Post { get; set; }

        public Comment()
        {
            this.DateCreated = DateTime.Now;                      
        }
    }

}