using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using YouTube.Models;

namespace YouTube.Controllers
{
    /// APIkey: AIzaSyBXDDQelEFdNgIpURbqWL7aJK2hZ19fotk
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        //private readonly string ApiKey = "AIzaSyBXDDQelEFdNgIpURbqWL7aJK2hZ19fotk";

        public HomeController()
        {
        }

        public async Task<IActionResult> Videos(string search)
        {
            //var oldUrl = "https://www.googleapis.com/youtube/v3/videos?search?part=snippet&chart=mostPopular&regionCode=PL&key=AIzaSyBXDDQelEFdNgIpURbqWL7aJK2hZ19fotk";
            var url = "https://www.googleapis.com/youtube/v3/search?key=AIzaSyBXDDQelEFdNgIpURbqWL7aJK2hZ19fotk&type=video&regionCode=PL&part=snippet&q=" + search;
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var ytStringResponse = await response.Content.ReadAsStringAsync();
                var ytResponse = JsonConvert.DeserializeObject<YouTubeResponse>(ytStringResponse);

                var ytVideos = ytResponse.items.Select(n => new Video
                {
                    Id = n.id.VideoId,
                    Title = n.snippet.title,
                    Description = n.snippet.description
                });

                return View(ytVideos);
            }

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
