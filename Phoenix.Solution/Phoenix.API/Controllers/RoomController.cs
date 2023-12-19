using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phoenix.API.Contracts.Interface;

namespace Phoenix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this._roomRepository.GetRooms());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(this._roomRepository.GetRoomByNumber(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
