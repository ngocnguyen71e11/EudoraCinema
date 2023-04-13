﻿using EudoraCinema.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace EudoraCinema.Controllers
{
    public class TaikhoanController : Controller
    {
        private const string http_base = "https://localhost:44313/";
        private const string direct_Film = "api/PhimAPI/";
        private const string direct_Ghe = "api/GheAPI/";
        private const string direct_Timeshow = "api/LichchieuAPI/";
        private const string method_GetAllFilm = "GetAll";
        private const string method_GetFilmCommingSoon = "GetPhimcommingsoon";
        private const string method_GetFilmbyID = "GetPhimbyID/";
        private const string direct_Taikhoan = "api/TaikhoanAPI/";

        // GET: Taikhoan
        public ActionResult Init()
        {
            return View("Login");
        }
        //Chức năng đăng nhập


        public ActionResult Login(FormCollection collection)
        {
            if(collection == null || collection.Count == 0)
            {
                return View();
            }     
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
                            Session["IDnguoidung"] = Convert.ToString( response.Content.ReadAsStringAsync().Result);
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

        //Chức năng hiển thị trang chủ


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
        //Chức năng hiển thị Lịch chiếu phim của từng bộ phim 
        public ActionResult MovieshowtimeList(int id,string sTenphim)
        {
            Session["PK_iPhimID"] = sTenphim;
            // Gọi API để lấy thông tin chi tiết phim
            using (HttpClient httpClient = new HttpClient())
            {
                //api/LichchieuAPI/12
                using (HttpResponseMessage response = httpClient.GetAsync(http_base + direct_Timeshow + id ).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = response.Content.ReadAsStringAsync().Result;
                        List<LichchieuEntity> Lichchieu = JsonConvert.DeserializeObject<List<LichchieuEntity>>(jsonData);
                        return View(Lichchieu);
                    }
                }
                // Nếu không lấy được thông tin phim từ API, trả về trang 404
                return HttpNotFound();
            }
        }
        //Chức năng đặt vé của phim theo ghế 
        public ActionResult BookTicket(int iGheID)
        {
            //'https://localhost:44313/api/GheAPI/bookSticker?PK_Ghe=49&sSoDienThoai=0347382190&PK_iPhongchieuID=1'
            // Gọi API để lấy thông tin chi tiết phim
            using (HttpClient httpClient = new HttpClient())
            {
                //https://localhost:44313/api/PhimAPI/1?PK_iPhimID=1
                using (HttpResponseMessage response = httpClient.GetAsync(http_base + direct_Ghe + "bookSticker?PK_Ghe=" + iGheID + "&sSoDienThoai=" + Session["IDnguoidung"] + "&PK_iPhongchieuID="+ Session["FK_iPhongchieuID"]).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = response.Content.ReadAsStringAsync().Result;
                        List<VeEntity> lstPhim = JsonConvert.DeserializeObject<List<VeEntity>>(jsonData);
                        return View(lstPhim);
                    }
                }
                // Nếu không lấy được thông tin phim từ API, trả về trang 404
                return HttpNotFound();
            }

            return View();
        }
        //'https://localhost:44313/api/GheAPI/23/4%2F3%2F2023/1?giochieu=23&ngaychieu=3%2F4%2F2023&FK_iPhongchieuID=1' 
        //Chức năng hiển thị danh sách ghế còn trống
        public ActionResult ListSeats(int giochieu, DateTime ngaychieu,long FK_iPhongchieuID)
        {
            Session["FK_iPhongchieuID"] = FK_iPhongchieuID;
            String ngay=ngaychieu.Month+"%2F"+ngaychieu.Day + "%2F" + ngaychieu.Year;
            List<GheEntity> lst_Ghe = new List<GheEntity>();
            using (HttpClient httpClient = new HttpClient())
            {
                //https://localhost:44313/api/PhimAPI/1?PK_iPhimID=1
                using (HttpResponseMessage response = httpClient.GetAsync(http_base+direct_Ghe+ giochieu+"/"+ ngay + "/"+FK_iPhongchieuID+ "?giochieu="+ giochieu + "&ngaychieu="+ ngay + "&FK_iPhongchieuID="+ FK_iPhongchieuID).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = response.Content.ReadAsStringAsync().Result;
                        lst_Ghe = JsonConvert.DeserializeObject<List<GheEntity>>(jsonData);
                        return View(lst_Ghe);
                    }
                }
                // Nếu không lấy được thông tin phim từ API, trả về trang 404
                return HttpNotFound();
            }
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
                        PhimEntity lstPhim = JsonConvert.DeserializeObject<PhimEntity>(jsonData);
                        return View(lstPhim);
                    }
                }
                // Nếu không lấy được thông tin phim từ API, trả về trang 404
                return HttpNotFound();
            }
                   
        }
        public ActionResult FilmCommingSoon(FormCollection collection)
        {
            // Gọi API để lấy thông tin chi tiết phim
            List<PhimEntity> lstUser;
            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.BaseAddress = new Uri(UriString);
                using (HttpResponseMessage response = httpClient.GetAsync(http_base + direct_Film + method_GetFilmCommingSoon).Result)
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
    }
}