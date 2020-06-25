using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using FactoryLayer.Services;
using PagedList;
using PagedList.Mvc;

namespace AGT_Web_Project.Controllers
{
    public class CustomerController : Controller
    {
        private Agt_Project_DBEntities _db = new Agt_Project_DBEntities();
        private CustomerService _customerService = new CustomerService();

        // GET: Customer
        public ActionResult Index(int page = 1)
        {
            var list = _customerService.GetList().ToPagedList(page, 5);
            return View(list);
        }
    }
}