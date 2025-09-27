using HotelAppLibrary.Data;
using HotelAppLibrary.Entities;

namespace TestApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            EfDataAccess data = new EfDataAccess();

            //var availableRoom = data.GetAvailableRooms(new DateTime(2025, 12, 3), new DateTime(2025, 12, 19), 1);
            //foreach (var roomtype in availableRoom)
            //{

            //    Console.WriteLine($"{roomtype.Id} - {roomtype.RoomNumber} - {roomtype.RoomTypeId} ");

            //}

            var bookings = data.GetBookings("Doe", new DateTime(2025, 12, 5));

            foreach (var booking in bookings)
            {
                Console.WriteLine($"Booking ID: {booking.Id}, Guest: {booking.FirstName} {booking.LastName}, Room: {booking.RoomNumber}, Start: {booking.StartDate}, End: {booking.EndDate}");
            }

            data.CheckInGuest(1);

            Console.WriteLine("Done processing");
        }
    }
}
