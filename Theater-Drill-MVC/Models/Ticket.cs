using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Theater_Drill_MVC.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name required for tickets validation in the theater")]
        [DisplayName("Recipient's Name")]
        public string OwnerName { get; set; }
        [DisplayName("Recipient's Email")]
        [Required(ErrorMessage = "Email required to send reciept for the purchase")]
        public string OwnerEmail { get; set; }
        public Auditorium Auditorium { get; set; }
        [Required]
        public int AuditoriumId { get; set; }
        public Movie Movie { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public int SeatRow { get; set; }
        [Required]
        public int SeatNumber { get; set; }
        [NotMapped]
        public string SeatsOrdered { get; set; }
    }
}
