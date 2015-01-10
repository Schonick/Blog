using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportClub.Models.Blog
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        [Display(Name = "Имя")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Введите название. Минимум 5 символов ")]
        public string Name { get; set; }

        public string UrlSlug { get; set; }

        [Display(Name = "Опис")]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Modified { get; set; }
        public Category()
        {
            if (this.Id > 0)
                this.Modified = DateTime.Now;

            else
            this.Created = DateTime.Now;
        }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
