using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportClub.Models
{
    public class Visits
    {
        [Key]
        public int VisitsID { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date, ErrorMessage = "Введіть дату")]
        public DateTime Date { get; set; }

        [Display(Name = "Время")]
        [DataType(DataType.Time, ErrorMessage = "Введіть години")]
        public DateTime Time { get; set; }

        [Display(Name = "Клиент")]
        public int ClientID { get; set; }

        [Display(Name = "Зал")]
        public int SportHallID { get; set; }

        [Display(Name = "Ключ от шкафчика")]
        [MaxLength(50)]
        public int KeyFromLocker { get; set; }

        [Display(Name = "Коментарий")]
        [MaxLength(150)]
        public string Comment { get; set; }

        public virtual Client Client { get; set; }
        public virtual SportHalls SportHalls { get; set; }
    }
}