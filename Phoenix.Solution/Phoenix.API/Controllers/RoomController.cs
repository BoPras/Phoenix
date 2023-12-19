using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phoenix.API.Contracts.Interface;
using Phoenix.API.Model;

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

        [HttpPost]
        public IActionResult Post([FromBody] RoomModel roomModel) 
        {
            try
            {
                var result = this._roomRepository.AddNewRoom(roomModel);
                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(string number, [FromBody] RoomModel roomModel)
        {
            try
            {
                var result = this._roomRepository.UpdateRoomByNumber(number, roomModel);
                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
