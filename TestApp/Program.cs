using HotelAppLibrary.Data;
using HotelAppLibrary.Entities;

namespace TestApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            EfDataAccess data = new EfDataAccess();

            var availableRoomTypes = data.GetAvailableRooms(new DateTime(2025, 12, 16), new DateTime(2025, 12, 19));
            foreach (var roomtype in availableRoomTypes)
            {

                Console.WriteLine($"{roomtype.Id} - {roomtype.Title} - {roomtype.Description} ");

            }

            Console.WriteLine("Done processing");
        }
    }
}
