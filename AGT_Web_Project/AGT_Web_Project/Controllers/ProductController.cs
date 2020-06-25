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
    public class ProductController : Controller
    {
        private Agt_Project_DBEntities _db = new Agt_Project_DBEntities();
        private ProductService _productService = new ProductService();

        // GET: Product
        public ActionResult Index(int page = 1)
        {
            var list = _productService.GetList().ToPagedList(page,5);
            return View(list);
        }

        public ActionResult Detail(int id)
        {
            Product product = _productService.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
    }
}