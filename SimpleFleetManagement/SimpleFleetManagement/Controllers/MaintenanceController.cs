using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleFleetManagement.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: Maintenance
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MaintenanceHeaderForm()
        {
            return View();
        }

        public ActionResult MaintenanceList()
        {
            List<MaintenanceDetailViewModel> model = new List<MaintenanceDetailViewModel>();
            return View(model);
        }

        //[HttpPost]
        //public ActionResult SaveMaintenance(MaintenanceHeaderViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //        }
        //    }
        //}
    }
}