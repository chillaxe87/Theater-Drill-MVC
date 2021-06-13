using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models
{
    public class Auditorium
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name the auditorium")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter number of rows")]
        [Range(1, 50)]
        public int Rows { get; set; }
        [Range(1, 50)]
        [Required(ErrorMessage = "Enter number of seats per row")]
        public int SeatNumberInRow { get; set; }
    }
}
