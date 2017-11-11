using SimpleFleetManagement.DataAccess;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleFleetManagement.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderForm()
        {
            return View();
        }

        public ActionResult FleetOrderList()
        {
            List<FleetOrderViewModel> models = new List<FleetOrderViewModel>();
            return View(models);
        }

        [HttpPost]
        public ActionResult FleetOrderItem(FleetOrderViewModel model)
        {
            return View(model);
        }

        public ActionResult AddFleetOrderItem(/*FleetOrderException fleetorderexception*/List<string> fleetexceptlistVal, List<string> driverexceptlistVal, List<string> assistantexceptlistVal, string startdateVal, string enddateVal)
        {
            FleetOrderException fleetorderexception = new FleetOrderException
            {
                fleetexceptlist = fleetexceptlistVal,
                driverexceptlist = driverexceptlistVal,
                assistantexceptlist = assistantexceptlistVal,
                startdate = startdateVal,
                enddate = enddateVal
            };


            ViewBag.FleetExceptList = FleetDataAccess.GetByFleetException(fleetorderexception).Select(flt => new SelectListItem
            {
                Value = flt.FleetId,
                Text = flt.FleetId + " " + flt.LicenseNumber + " " + flt.BrandTypeName
            });

            ViewBag.DriverExceptList = new SelectList(CrewDataAccess.GetByDriverException(fleetorderexception), "CrewId", "CrewName");

            ViewBag.AssistantExceptList = new SelectList(CrewDataAccess.GetByAssistantException(fleetorderexception), "CrewId", "CrewName");

            ViewBag.StartDate = fleetorderexception.startdate;

            ViewBag.EndDate = fleetorderexception.enddate;
            
            return View();
        }
    }
}