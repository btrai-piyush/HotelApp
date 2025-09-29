using HotelAppLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotelAppMVC.Models
{
    public class RoomSearchModel
    {
        [DataType(DataType.Date)]
        [BindProperty]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [BindProperty]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        public List<RoomType> AvailableRoomTypes { get; set; }
    }


}
