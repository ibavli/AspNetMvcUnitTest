using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcAndUnitTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.isim = "ali veli";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult OgrenciMetod1(int Id)
        {
            List<OgrenciModel> model = new List<OgrenciModel>();
            var ogrenci = new OgrenciModel { Id = 1, Ad = "ali", Soyad = "veli" };
            model.Add(ogrenci);

            var _ogrenci = model.Where(i => i.Id == Id).FirstOrDefault();
            return View("Ogrenci", _ogrenci);
        }

        public ActionResult OgrenciMetod2(int Id)
        {
            if (Id <= 0)
                return RedirectToAction("Index");

            List<OgrenciModel> model = new List<OgrenciModel>();
            var ogrenci = new OgrenciModel { Id = 1, Ad = "ali", Soyad = "veli" };
            model.Add(ogrenci);

            var _ogrenci = model.Where(i => i.Id == Id).FirstOrDefault();
            return View("Ogrenci", _ogrenci);
        }

        public ActionResult OgrenciMetod3(int Id)
        {
            if (Id <= 0)
                return RedirectToAction("Index");

            List<OgrenciModel> model = new List<OgrenciModel>();
            var ogrenci = new OgrenciModel { Id = 1, Ad = "ali", Soyad = "veli" };
            model.Add(ogrenci);

            var _ogrenci = model.Where(i => i.Id == Id).FirstOrDefault();
            return View("Ogrenci", _ogrenci);

        }
        public class OgrenciModel
        {
            public int Id { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
        }

        public JsonResult JsonOgrenci()
        {
            var ogrenci = new OgrenciModel { Id = 1, Ad = "ali", Soyad = "veli" };
            return Json(ogrenci);
        }

        public ActionResult Sayfa1()
        {
            return View("Sayfa2");
        }


        public ActionResult ListeOgrenciModel()
        {
            return View(new List<OgrenciModel>());
        }
    }
}