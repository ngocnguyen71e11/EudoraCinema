using EudoraCinema.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace EudoraCinema.Controllers
{
    public class AdminController : Controller
    {
        private const string url_base = "https://localhost:44313/";
        private const string direct_insertFilm = "api/PhimAPI";
        // GET: Admin
        public ActionResult FilmInsert(FormCollection collection)
        {
            try
            {
                if (collection == null || collection.Count == 0)
                {
                    return View();
                }
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

                    using (HttpResponseMessage response = httpClient.PostAsJsonAsync(url_base + direct_insertFilm, phimEntity).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("HomePage", "Taikhoan");

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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
