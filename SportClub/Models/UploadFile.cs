using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportClub.Models
{
    public class UploadFile
    {
        [Key]
        [Display(Name = "№")]
        public int UploadFileID { get; set; }
        [Display(Name = "Шлях до файлу")]
        public string PatchToFile { get; set; }
    }
}