using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleFleetManagement.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<CrewViewModel> model = CrewDataAccess.GetAll();
            return View(model);
        }
    }
}