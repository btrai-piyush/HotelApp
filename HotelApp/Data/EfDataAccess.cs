using HotelAppLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppLibrary.Data
{
    public class EfDataAccess
    {
        private readonly HotelAppContext context = new HotelAppContext();

        public List<RoomType> GetAvailableRooms(DateTime startDate, DateTime endDate)
        {
            // To find available RoomTypes, we need to check if any Room of that type has NO bookings that overlap the given dates.
            // We'll join Rooms and Bookings, and filter accordingly.

            var availableRoomTypes = context.RoomTypes
                .Include(rt => rt.Rooms)
                .Where(rt => rt.Rooms.Any(room =>
                    !context.Bookings.Any(booking =>
                        booking.RoomId == room.Id &&
                        (
                            (startDate >= booking.StartDate && startDate <= booking.EndDate) ||
                            (endDate >= booking.StartDate && endDate <= booking.EndDate) ||
                            (startDate <= booking.StartDate && endDate >= booking.EndDate)
                        )
                    )
                ))
                .ToList();

            return availableRoomTypes;
        }

    }
}
