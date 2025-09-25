using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppLibrary.Models
{
    public class RoomType
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Title { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public Room? Rooms { get; set; }
    }
}
