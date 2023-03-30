using EudoraCinema.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EudoraCinema.Controllers
{
    public class TaikhoanController : Controller
    {
        // GET: Taikhoan
        public ActionResult Login(FormCollection collection)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string Email = collection["sEmail"];
                string Pass = collection["sMatkhau"];
                //httpClient.BaseAddress = new Uri(UriString);
                using (HttpResponseMessage response = httpClient.GetAsync("http://192.168.1.26:8043/api/TaikhoanAPI/"+Email+"/"+Pass).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return View("Index");
                    }
                    else
                    {
                        // Handle error response
                        return View();
                    }
                }
            }

            return View();
        }
    }
}