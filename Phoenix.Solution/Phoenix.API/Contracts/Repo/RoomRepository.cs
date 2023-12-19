using DataAccess;
using Phoenix.API.Contracts.Interface;
using Phoenix.API.Model;

namespace Phoenix.API.Contracts.Repo
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DapperContext _dapperContext;

        public RoomRepository(IConfiguration configuration)
        {
            _dapperContext = new DapperContext(configuration?.GetConnectionString("SqlConnection"));
        }

        
        
        public List<RoomModel> GetRooms()
        {
            string query = "SELECT * FROM Rooms";
            List<RoomModel> result = this._dapperContext.GetList<RoomModel>(query, new Dapper.DynamicParameters { });
            return result;
        }

        public List<RoomModel> GetRoomByNumber(string number)
        {
            return GetRooms().Where(r => r.Number == number).ToList();
        }

        public void AddNewRoom(RoomModel room)
        {

        }
    }
}
