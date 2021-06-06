using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter the movies name")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the movies genre")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Please enter the movies director")]
        public string Director { get; set; }
        public string Cast { get; set; }
        [Required(ErrorMessage = "Please enter the movies language")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Please enter the movies length in minutes")]
        [Range(1, 500)]
        public int LengthInMinutes { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the ticket price")]
        [Range(1, 500)]
        public decimal PricePerTicket { get; set; }
        [Url]
        public string ImageUrl { get; set; }
    }
}
