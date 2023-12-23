using Microsoft.AspNetCore.Mvc;
using Phoenix.Web.Models.YuGiOh;
using System.Text.Json;

namespace Phoenix.Web.Controllers
{
    public class YuGiOhController : Controller
    {
        private readonly HttpClient _httpClient;

        public YuGiOhController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://db.ygoprodeck.com");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("api/v7/cardinfo.php");
                if (response.IsSuccessStatusCode)
                {
                    var responsData = await response.Content.ReadAsStringAsync();
                    var item = JsonSerializer.Deserialize<CardViewModel>(responsData, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,

                    });

                    ViewData["Cards"] = item;
                    return View();
                }
                else
                {
                    ViewBag.Error = "Failed to fetch data from the room API";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "An error occured: " + e.Message;
                return View();
            }
        }
    }
}
