using Phoenix.API.Model;

namespace Phoenix.API.Contracts.Interface
{
    public interface IRoomRepository
    {
        List<RoomModel> AddNewRoom(RoomModel room);
        List<RoomModel> GetRoomByNumber(string number);
        List<RoomModel> GetRooms();
        List<RoomModel> UpdateRoomByNumber(string number, RoomModel room);
    }
}
