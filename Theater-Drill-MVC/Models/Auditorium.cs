using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models
{
    public class Auditorium
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Rows { get; set; }
        public int SeatNumberInRow { get; set; }
    }
}
