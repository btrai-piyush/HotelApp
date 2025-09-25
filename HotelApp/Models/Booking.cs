using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppLibrary.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public int GuestId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
    }
}
