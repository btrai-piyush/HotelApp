using HotelAppLibrary.Data;

namespace TestApp
{
    public class Program
    {
        static void Main(string[] args)
        {


            var rooms = EfDataAccess.GetAllRooms();
            foreach (var room in rooms)
            {
                Console.WriteLine(room);
            }

            Console.WriteLine("Done processing");
        }
    }
}
