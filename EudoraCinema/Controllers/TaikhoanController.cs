using EudoraCinema.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EudoraCinema.Controllers
{
    public class TaikhoanController : Controller
    {
        private const string http_base = "https://localhost:44313/";
        private const string direct_Film = "api/PhimAPI/";
        private const string method_GetAllFilm = "GetAll";
        private const string method_GetFilmbyID = "GetPhimbyID/";
        private const string direct_Taikhoan = "api/TaikhoanAPI/";

        // GET: Taikhoan
        public ActionResult Init()
        {
            return View("Login");
        }
        public ActionResult Login(FormCollection collection)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string Email = collection["sEmail"];
                string Pass = collection["sMatkhau"];
                try
                {
                    using (HttpResponseMessage response = httpClient.GetAsync(http_base+direct_Taikhoan + Email + "/" + Pass).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                                
                                return RedirectToAction("HomePage");
                        }
                        else
                        {
                            // Handle error response
                            return View();
                        }
                    }
                }
                catch (Exception ex) 
                {
                    return View(); 
                }
            }
        }

        public ActionResult Logout() { return View(); }
        public ActionResult HomePage()
        {
            List<PhimEntity> lstUser;
            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.BaseAddress = new Uri(UriString);
                using (HttpResponseMessage response = httpClient.GetAsync(http_base + direct_Film + method_GetAllFilm).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = response.Content.ReadAsStringAsync().Result;
                        lstUser = JsonConvert.DeserializeObject<List<PhimEntity>>(jsonData);
                        return View(lstUser);
                    }
                    else
                    {
                        // Handle error response
                        return View();
                    }
                }
            }
        }
        public ActionResult MovieshowtimeList(FormCollection collection)
        {
            return View();
        }
        public ActionResult BookTicket(FormCollection collection)
        {
            return View();
        }
        public ActionResult ListSeats(FormCollection collection)
        {
            return View();
        }
        public ActionResult FilmDetail(int id)
        {
            // Gọi API để lấy thông tin chi tiết phim
            using (HttpClient httpClient = new HttpClient())
            {
                //https://localhost:44313/api/PhimAPI/1?PK_iPhimID=1
                using (HttpResponseMessage response = httpClient.GetAsync(http_base + direct_Film +id+"?PK_iPhimID="+ id).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = response.Content.ReadAsStringAsync().Result;
                        PhimEntity phim = JsonConvert.DeserializeObject<PhimEntity>(jsonData);
                        return View(phim);
                    }
                }
                // Nếu không lấy được thông tin phim từ API, trả về trang 404
                return HttpNotFound();
            }
                   
        }
    }
}