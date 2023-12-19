using Dapper;
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

        public List<RoomModel> AddNewRoom(RoomModel room)
        {
            string query = "INSERT INTO Rooms(Number, FLoor, Room_Type, Guest_Limit, Description, Cost)VALUES(@Number, @Floor, @Room_Type, @Guest_Limit, @Description, @Cost)";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Number", room.Number, System.Data.DbType.String);
            parameters.Add("@Floor", room.Floor, System.Data.DbType.String);
            parameters.Add("@Room_Type", room.Room_type, System.Data.DbType.String);
            parameters.Add("@Guest_Limit", room.Guest_Limit, System.Data.DbType.String);
            parameters.Add("@Description", room.Description, System.Data.DbType.String);
            parameters.Add("@Cost", room.Cost, System.Data.DbType.String);

            this._dapperContext.Update<RoomModel>(query, parameters);
            return this.AddNewRoom(room);
        }

        public List<RoomModel> UpdateRoomByNumber(string number, RoomModel room)
        {
            string query = "UPDATE Rooms SET Floor = @Floor, " +
                           "Room_Type = @Room_Type, " +
                           "Guest_Limit = @Guest_Limit, " +
                           "Description = @Description, " +
                           "Cost = @Cost " +
                           "WHERE Number = @Number";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Floor", room.Floor, System.Data.DbType.String);
            parameters.Add("@Room_Type", room.Room_type, System.Data.DbType.String);
            parameters.Add("@Guest_Limit", room.Guest_Limit, System.Data.DbType.String);
            parameters.Add("@Description", room.Description, System.Data.DbType.String);
            parameters.Add("@Cost", room.Cost, System.Data.DbType.String);
            parameters.Add("@Number", number, System.Data.DbType.String);

            this._dapperContext.Update<RoomModel> (query, parameters);
            return this.UpdateRoomByNumber(number, room);
        }

    }
}
