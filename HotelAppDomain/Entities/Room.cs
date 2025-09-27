using HotelAppLibrary.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppLibrary.Entities
{
    public class Room
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string RoomNumber { get; set; }

        [Required]
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }

        public Booking? Bookings { get; set; }
    }
}
