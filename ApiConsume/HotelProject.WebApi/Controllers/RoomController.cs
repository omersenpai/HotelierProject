using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomRoom;

        public RoomController(IRoomService roomRoom)
        {
            _roomRoom = roomRoom;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomRoom.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom(Room room)
        {


            _roomRoom.TInsert(room);

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var values = _roomRoom.TGetById(id);
            _roomRoom.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _roomRoom.TUpdate(room);
            return Ok();
        }


        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var values = _roomRoom.TGetById(id);
            return Ok(values);
        }
    }
}
