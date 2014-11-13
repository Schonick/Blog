using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportClub.Models.Blog
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public string ShortDescription { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Мета")]
        public string Meta { get; set; }

        public string UrlSlug { get; set; }

         [Display(Name = "Разместить?")]
        public bool Published { get; set; }

        [Display(Name = "Размещено")]
         public DateTime PublishDate { get; set; }

        [Display(Name = "Изменино")]
        public DateTime? Modified { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}