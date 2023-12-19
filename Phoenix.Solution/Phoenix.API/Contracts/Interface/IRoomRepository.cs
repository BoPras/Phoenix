using Phoenix.API.Model;

namespace Phoenix.API.Contracts.Interface
{
    public interface IRoomRepository
    {
        List<RoomModel> GetRoomByNumber(string number);
        List<RoomModel> GetRooms();
    }
}
