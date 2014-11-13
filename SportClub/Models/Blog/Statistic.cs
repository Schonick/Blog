using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportClub.Models.Blog
{
    public class Statistic
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Application { get; set; }

        [StringLength(40)]
        public string Identifier { get; set; }

        public int Users { get; set; }

        [StringLength(40)]
        public int Visits { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Modified { get; set; }

        public Statistic()
        {
            this.Created = DateTime.Now;
        }
    }
}
