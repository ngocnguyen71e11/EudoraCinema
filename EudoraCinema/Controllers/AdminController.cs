using EudoraCinema.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace EudoraCinema.Controllers
{
    public class AdminController : Controller
    {

        private const string url_base = "https://localhost:44313/";
        private const string direct_insertFilm = "api/PhimAPI";
        // GET: Admin
        //5 [HttpPost]
        public ActionResult FilmInsert(FormCollection collection)
        {
            PhimEntity phimEntity = new PhimEntity();
            using (HttpClient httpClient = new HttpClient())
            {
                phimEntity.sTenphim = collection["sTenphim"];
                phimEntity.sThoiluong = collection["sThoiluong"];
                phimEntity.dNgaykhoichieu = Convert.ToDateTime(collection["dNgaykhoichieu"]);
                phimEntity.sDaodien = collection["sDaodien"];
                phimEntity.sDienvien = collection["sDienvien"];
                phimEntity.sNgonngu = collection["sNgonngu"];
                phimEntity.sMota = collection["sMota"];
                phimEntity.sAnh = collection["sAnh"];
                try
                {
                    using (HttpResponseMessage response = httpClient.PostAsJsonAsync(url_base + direct_insertFilm, phimEntity).Result)
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
                catch (Exception ex) { return View(); }


            }
        }
        public ActionResult FilmInsertPage(FormCollection collection)
        {
            PhimEntity phimEntity = new PhimEntity();
            using (HttpClient httpClient = new HttpClient())
            {
                phimEntity.sTenphim = collection["sTenphim"];
                phimEntity.sThoiluong = collection["sThoiluong"];
                phimEntity.dNgaykhoichieu = Convert.ToDateTime(collection["dNgaykhoichieu"]);
                phimEntity.sDaodien = collection["sDaodien"];
                phimEntity.sDienvien = collection["sDienvien"];
                phimEntity.sNgonngu = collection["sNgonngu"];
                phimEntity.sMota = collection["sMota"];
                phimEntity.sAnh = collection["sAnh"];
                try
                {
                    using (HttpResponseMessage response = httpClient.PostAsJsonAsync(url_base + direct_insertFilm, phimEntity).Result)
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
                catch (Exception ex) { return View(); }

            }
        }
    }
}