using HotelAppLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppLibrary.Data
{
    public static class EfDataAccess
    {
        private static readonly HotelAppContext context = new HotelAppContext();

        //public List<RoomType> GetAvailableRooms(DateTime startDate,DateTime endDate)
        //{
        //    var rooms=;

        //        return rooms;
        //}

        public static List<Room> GetAllRooms()
        {
            var rooms = context.Rooms.ToList();

            return rooms;
        }
    }
}
