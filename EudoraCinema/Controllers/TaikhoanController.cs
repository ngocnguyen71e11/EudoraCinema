﻿using EudoraCinema.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EudoraCinema.Controllers
{
    public class TaikhoanController : Controller
    {
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
                    using (HttpResponseMessage response = httpClient.GetAsync("https://localhost:44313/api/TaikhoanAPI/" + Email + "/" + Pass).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                                
                                return RedirectToAction("Index");
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
        public ActionResult Index()
        {
            List<PhimEntity> lstUser;
            using (HttpClient httpClient = new HttpClient())
            {
                //httpClient.BaseAddress = new Uri(UriString);
                using (HttpResponseMessage response = httpClient.GetAsync("https://localhost:44313/api/TaikhoanAPI/" + "GetAll").Result)
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