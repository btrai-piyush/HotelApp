using HotelAppLibrary.Data;
using HotelAppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelAppMVC.Controllers
{
    public class RoomSearchController : Controller
    {
        private readonly EfDataAccess _efDataAccess;

        public RoomSearchController(EfDataAccess efDataAccess)
        {
            _efDataAccess = efDataAccess;
        }

        public IActionResult SearchRoom()
        {
            return View(new RoomSearchModel());
        }

        [HttpPost]
        public async Task<IActionResult> SearchRoom(RoomSearchModel roomSearchModel)
        {
            roomSearchModel.AvailableRoomTypes = await _efDataAccess.GetAvailableRoomTypes(roomSearchModel.StartDate, roomSearchModel.EndDate);

            return View(roomSearchModel);
        }

        public IActionResult ContinueBooking(DateTime startDate, DateTime endDate, int roomTypeId)
        {
            BookRoomModel bookRoomModel = new BookRoomModel
            {
                RoomTypeId = roomTypeId,
                StartDate = startDate,
                EndDate = endDate,
            };
            return RedirectToAction("BookRoom", "RoomSearch", bookRoomModel);
        }

        public async Task<IActionResult> BookRoom(BookRoomModel bookRoomModel)
        {
            bookRoomModel.RoomType = await _efDataAccess.GetRoomTypeById(bookRoomModel.RoomTypeId);
            return View(bookRoomModel);
        }

        [HttpPost]
        public IActionResult FinaliseBooking(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId)
        {
            _efDataAccess.BookGuest(firstName, lastName, startDate, endDate, roomTypeId);
             return RedirectToAction("Index", "Home");
        }

    }
}
