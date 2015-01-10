using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportClub.Models.Blog
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Title { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Краткое описание")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string ShortDescription { get; set; }

        [Display(Name = "Описание")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Мета")]
        public string Meta { get; set; }

        public string UrlSlug { get; set; }

        [Display(Name = "Разместить?")]
        public bool Published { get; set; }

        [Display(Name = "Размещено")]
        [DataType(DataType.DateTime)]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Изменино")]
        [DataType(DataType.DateTime)]
        public DateTime? Modified { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }

        public Post()
        {
           
            //if (this.Author!=null)
            //{ this.Author = "admin"; }
            if (this.PublishDate != null)
            {
                //this.PublishDate = this.PublishDate;
                //else
                this.Modified = DateTime.Now;
            }
            else { this.PublishDate = DateTime.Now;
            }

        }
        //public Post(DateTime? modifedDate)
        //{
        //    this.Modified = modifedDate;
        //}
    }
}