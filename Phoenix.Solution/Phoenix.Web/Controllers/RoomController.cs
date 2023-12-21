using Microsoft.AspNetCore.Mvc;
using Phoenix.Web.Models.Room;
using System.Text.Json;

namespace Phoenix.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly HttpClient _httpClient;

        public RoomController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5281");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("api/room");
                if (response.IsSuccessStatusCode)
                {
                    var responsdata = await response.Content.ReadAsStringAsync();
                    var rooms = JsonSerializer.Deserialize<List<RoomViewModel>>(responsdata, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });

                    ViewData["Rooms"] = rooms;
                    return View();
                }
                else
                {
                    ViewBag.Error = "Failed to fetch data from the room API";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occured: " + ex.Message;
                return View();
            }
        }
    }
}
