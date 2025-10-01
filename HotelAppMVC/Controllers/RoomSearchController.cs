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

        [HttpGet]
        public IActionResult BookRoom(BookRoomModel bookRoomModel)
        {

            return View(bookRoomModel);
        }


    }
}
