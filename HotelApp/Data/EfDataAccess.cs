using HotelAppLibrary.Entities;
using HotelAppLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public List<RoomType> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
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

        public List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate, int roomTypeId)
        {
            var availableRooms = context.Rooms.Where(r => !context.Bookings.Any(b =>
                                                    b.RoomId == r.Id
                                                    && ((startDate >= b.StartDate && startDate <= b.EndDate)
                                                    || (endDate >= b.StartDate && endDate <= b.EndDate)
                                                    || (startDate <= b.StartDate && endDate >= b.EndDate)))
                                                    && r.RoomTypeId == roomTypeId
            )
            .ToList();

            if (availableRooms.IsNullOrEmpty())
            {
                Console.WriteLine("No such room type available");
            }

            return availableRooms;
        }

        public void BookGuest(string firstName,
                              string LastName,
                              DateTime startDate,
                              DateTime endDate,
                              int roomTypeId)
        {
            var newGuest = new Guest
            {

                FirstName = firstName,
                LastName = LastName
            };
            context.Guests.Add(newGuest);
            context.SaveChanges();

            RoomType? roomType = context.RoomTypes.Where(rt => rt.Id == roomTypeId).First();

            TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);

            List<Room> availableRooms = GetAvailableRooms(startDate, endDate, roomTypeId);

            var newBooking = new Booking
            {
                RoomId = availableRooms.First().Id,
                GuestId = newGuest.Id,
                StartDate = startDate,
                EndDate = endDate,
                TotalCost = timeStaying.Days * roomType.Price
            };
            context.Bookings.Add(newBooking);
            context.SaveChanges();
        }

        public List<BookingFullModel> GetBookings(string lastName, DateTime date)
        {
            var booking = (from b in context.Set<Booking>()
                           join g in context.Set<Guest>()
                           on b.GuestId equals g.Id
                           join r in context.Set<Room>()
                           on b.RoomId equals r.Id
                           join t in context.Set<RoomType>()
                           on r.RoomTypeId equals t.Id
                           where b.StartDate == date && g.LastName == lastName
                           select new BookingFullModel
                           {
                               Id = b.Id,
                               RoomId = b.RoomId,
                               GuestId = b.GuestId,
                               StartDate = b.StartDate,
                               EndDate = b.EndDate,
                               CheckedIn = b.CheckedIn,
                               TotalCost = b.TotalCost,
                               Title = t.Title,
                               Description = t.Description,
                               Price = t.Price,
                               RoomNumber = r.RoomNumber,
                               RoomTypeId = r.RoomTypeId,
                               FirstName = g.FirstName,
                               LastName = g.LastName
                           })
                           .ToList();

            return booking;
        }

        public void CheckInGuest(int bookingId)
        {
            var booking = context.Bookings.FirstOrDefault(i => i.Id == bookingId);
            if (booking != null)
            {
                booking.CheckedIn = true;
                context.SaveChanges();
            }
        }

    }
}
