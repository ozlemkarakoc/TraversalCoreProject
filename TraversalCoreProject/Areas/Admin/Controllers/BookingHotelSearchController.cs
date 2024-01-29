using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TraversalCoreProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BookingHotelSearchController : Controller
    {
        public async Task< IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?order_by=popularity&checkout_date=2024-05-20&filter_by_currency=EUR&locale=en-gb&units=metric&dest_id=-1456928&dest_type=city&adults_number=2&room_number=1&checkin_date=2024-05-19&include_adjacency=true&page_number=0&children_number=2&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0"),
                Headers =
    {
        { "X-RapidAPI-Key", "e62602a035mshfe581ad1c8f4dc6p1c0db6jsn4f5f7db015c2" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyReplace = body.Replace(".", "");
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(bodyReplace);
                return View(values.result);
            }
        }
        [HttpGet]
        public IActionResult GetCityDestID()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> GetCityDestID(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={p}"),
                Headers =
    {
        { "X-RapidAPI-Key", "e62602a035mshfe581ad1c8f4dc6p1c0db6jsn4f5f7db015c2" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return View();
            }
        }
    }
}
