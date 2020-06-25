using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using FactoryLayer.Services;
using PagedList;
using PagedList.Mvc; // Sayfalama için eklendi ...

namespace AGT_Web_Project.Controllers
{
    public class ReportController : Controller
    {
        private Agt_Project_DBEntities _db = new Agt_Project_DBEntities();

        // GET: Report
        public ActionResult Index(int page = 1)
        {
            var list = _db.SelectAllOrders().ToList().ToPagedList(page, 7); // Tüm siparişler gelir ...
            return View(list);
        }

        public ActionResult Date(DateTime? dtpStartDate, DateTime? dtpFinishDate, int page = 1) // Girilen tarih aralığına göre veri getirir ...
        {
            var list = _db.SelectByOrderDate(dtpStartDate, dtpFinishDate).ToList().ToPagedList(page, 5);

            ViewBag.FirstDate = dtpStartDate;
            ViewBag.LastDate = dtpFinishDate;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ByDate", list);
            }
            else
            {
                return View(list);
            }
        }

        public ActionResult Price(decimal? txtMinPrice, decimal? txtMaxPrice, int page = 1) // Girilen fiyat aralığına göre veri getirir ...
        {
            var list = _db.SelectByOrderPrice(txtMinPrice, txtMaxPrice).ToList().ToPagedList(page, 7);

            ViewBag.FirstPrice = txtMinPrice;
            ViewBag.LastPrice = txtMaxPrice;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ByPrice", list);
            }
            else
            {
                return View(list);
            }
        }

        public ActionResult UnSold(int page = 1)
        {
            var list = _db.SelectByUnSoldProduct().ToList().ToPagedList(page, 7); // Hiç satılmayan ürünleri getirir...
            return View(list);
        }

        public ActionResult BestSelling(int page = 1)
        {
            var list = _db.SelectByBestSellingProduct().ToList().ToPagedList(page, 7); // En çok satılan ürünleri ve adetini getirir...
            return View(list);
        }

        public ActionResult Active(int page = 1) // Aktif müşterilerin siparişlerini getirir ...
        {
            var list = _db.SelectByActiveCustomersOrders().ToList().ToPagedList(page,7);
            return View(list);
        }

        public ActionResult Passive(int page = 1) // Aktif müşterilerin siparişlerini getirir ...
        {
            var list = _db.SelectByPassiveCustomersOrders().ToList().ToPagedList(page, 7);
            return View(list);
        }
    }
}