using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UI.Models;
using DAL.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {      
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;

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
        public async Task<IActionResult> Sanpham()
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync("https://localhost:44308/api/Nguoidung");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<SanPham>>(jsonResponse);
            if (response.IsSuccessStatusCode)
            {
                return View(list);
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Giohang()
        {
            return View();
        }
        public IActionResult Banggia()
        {
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            
            return RedirectToAction(nameof(Sanpham));
            
        }
    }
}
