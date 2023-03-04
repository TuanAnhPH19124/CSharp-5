using DAL.Data;
using DAL.Data.Cart;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UI.Models;
using UI.ViewModels;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private DbContexts _db = new DbContexts();
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory = null;
        private readonly IConfiguration _configuration = null;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;

        }
        public async Task<IActionResult> Index()
        {
            var thongtin = HttpContext.Session.GetString("email");
            ViewData["thongtin"] = thongtin;
            using HttpClient client = _httpClientFactory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync("https://localhost:44308/api/SanPhamChiTiets");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<SanPhamChiTiet>>(jsonResponse);
            response.EnsureSuccessStatusCode();
            return View(list);
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
            var thongtin = HttpContext.Session.GetString("email");
            ViewData["thongtin"] = thongtin;
            string? httpClientName = _configuration["HttpClientName"];
            using HttpClient client = _httpClientFactory.CreateClient(httpClientName ?? "");
            using HttpResponseMessage response = await client.GetAsync("api/SanPhamChiTiets");
            //using HttpResponseMessage response = await client.GetAsync("https://localhost:44308/api/SanPhamChiTiets");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var list = new Sanphamvm() { sanPhamChiTiets = JsonConvert.DeserializeObject<List<SanPhamChiTiet>>(jsonResponse) };
            response.EnsureSuccessStatusCode();
            return View(list);
        }

        public async Task<IActionResult> AddProduct([Bind()] Sanphamvm product)
        {
            var thongtin = HttpContext.Session.GetString("email");
            ViewData["thongtin"] = thongtin;
            using HttpClient client = _httpClientFactory.CreateClient();
            using HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44308/api/SanPhamChiTiets", product.SanPhamChiTiet);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Sanpham");
            }
            return NotFound();
        }
        public async Task<IActionResult> AddGiohang(int id)
        {
            var thongtin = HttpContext.Session.GetString("email");
            ViewData["thongtin"] = thongtin;
            var giohang = new GioHang() { SoLuong = 1, Id_spct = id, Id_nguoidung = Convert.ToInt32(HttpContext.Session.GetString("idND")), IdGioHang = HttpContext.Session.GetString("idGH") };
            using HttpClient client = _httpClientFactory.CreateClient();
            using HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44308/api/Giohangs", giohang);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Giohang");
            }
            return NotFound();
        }
        [HttpPost]
        [Route("Home/Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SanPhamChiTiet sanpham)
        {
            var thongtin = HttpContext.Session.GetString("email");
            ViewData["thongtin"] = thongtin;
            using HttpClient client = _httpClientFactory.CreateClient();
            using HttpResponseMessage response = await client.PutAsJsonAsync($"api/SanPhamChiTiets/{id}", sanpham);
            response.EnsureSuccessStatusCode();
            return Ok();
        }
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var thongtin = HttpContext.Session.GetString("email");
            ViewData["thongtin"] = thongtin;
            using HttpClient client = _httpClientFactory.CreateClient();
            using HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44308/api/SanPhamChiTiets/{Id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Sanpham");
            }
            return NotFound();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([Bind()] AccountVM vM)
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync("https://localhost:44308/api/NguoiDungs");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<IEnumerable<NguoiDung>>(jsonResponse);
            var user = list.FirstOrDefault(ng => ng.Email == vM.Email && ng.Password == vM.Pass);
            if (user != null)
            {
                var gh = user.gioHangs.Count();

                if (gh == 0)
                {
                    HttpContext.Session.SetString("idGH", Guid.NewGuid().ToString());
                }
                else
                {
                    var id = user.gioHangs.First();
                    HttpContext.Session.SetString("idGH", id.IdGioHang.ToString());

                }
            }
            HttpContext.Session.SetString("email", user.Email);
            HttpContext.Session.SetString("idND", user.Id.ToString());
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> thanhToan()
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            using HttpResponseMessage responseGH = await client.GetAsync("api/giohangs/getDelete");
            responseGH.EnsureSuccessStatusCode();
            var jsonResponse = await responseGH.Content.ReadAsStringAsync();
            var gioHangs = JsonConvert.DeserializeObject<IEnumerable<GioHang>>(jsonResponse).Where(p => p.Id_nguoidung == int.Parse(HttpContext.Session.GetString("idND")));
            var hd = new HoaDon()
            {
                HinhThucThanhToan = "Tien mat",
                GhiChu = "nothing",
                Id_diachi = 1,
                hoaDonChiTiets = new List<HoaDonChiTiet>()
            };
            var hdct = new List<HoaDonChiTiet>();
            foreach (var item in ShoppingCart.gioHangs)
            {
                hdct.Add(new HoaDonChiTiet()
                {
                    Id_spct = item.Id_spct,
                    SoLuong = item.SoLuong,
                    Price = item.sanPhamChiTiet.GianBan,
                });
            }
            hd.hoaDonChiTiets.AddRange(hdct);
            using HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44308/api/hoadons", hd);
            response.EnsureSuccessStatusCode();
            using HttpResponseMessage responseMessage = await client.PostAsJsonAsync("api/giohangs/clear", gioHangs);
            responseMessage.EnsureSuccessStatusCode();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("idGH");
            HttpContext.Session.Remove("idND");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Giohang()
        {
            var thongtin = HttpContext.Session.GetString("email");
            ViewData["thongtin"] = thongtin;
            var id_nguoidung = HttpContext.Session.GetString("idND");
            using HttpClient client = _httpClientFactory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync("api/GioHangs/");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var lists = JsonConvert.DeserializeObject<IEnumerable<GioHang>>(jsonResponse);
            response.EnsureSuccessStatusCode();
            ShoppingCart.gioHangs = lists.Where(x => x.Id_nguoidung == int.Parse(id_nguoidung));
            return View(ShoppingCart.gioHangs);
        }
        public async Task<IActionResult> DeleteCart(int Id)
        {
            var thongtin = HttpContext.Session.GetString("email");
            ViewData["thongtin"] = thongtin;
            using HttpClient client = _httpClientFactory.CreateClient();
            using HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44308/api/GioHangs/{Id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Giohang");
            }
            return NotFound();
        }
        public async Task<IActionResult> Hoadon()
        {
            var thongtin = HttpContext.Session.GetString("email");
            ViewData["thongtin"] = thongtin;
            using HttpClient client = _httpClientFactory.CreateClient();
            using HttpResponseMessage response = await client.GetAsync("api/HoaDons");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<IEnumerable<HoaDon>>(jsonResponse);
            response.EnsureSuccessStatusCode();
            return View(list);
        }
        
        public IActionResult GetAll()
        {
            return RedirectToAction(nameof(Sanpham));
        }

        [HttpPost]
        [Route("Home/vl/{id}")]
        public async Task<IActionResult> UpdateGioHang(int id, [FromBody] GioHang gioHang)
        {
            using HttpClient client = _httpClientFactory.CreateClient();
            using HttpResponseMessage responseMessage = await client.PutAsJsonAsync($"api/GioHangs/{id}", gioHang);
            responseMessage.EnsureSuccessStatusCode();
            return NoContent();
        }
    }
}