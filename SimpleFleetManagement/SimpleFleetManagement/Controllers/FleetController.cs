using SimpleFleetManagement.DataAccess;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleFleetManagement.Controllers
{
    public class FleetController : Controller
    {
        // GET: Fleet
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<FleetViewModel> model = FleetDataAccess.GetAll();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.KaroseriList = new SelectList(KaroseriDataAccess.GetAll(), "KaroseriId", "Description");
            ViewBag.MerkBusList = new SelectList(MerkBusDataAccess.GetAll(), "MerkId", "Description");
            ViewBag.TypeBusList = new SelectList(TypeBusDataAccess.GetByMerkBus(""), "TypeId", "Description");
            return View();
        }

        public ActionResult Edit(int id)
        {
            FleetViewModel model = FleetDataAccess.GetById(id);
            ViewBag.KaroseriList = new SelectList(KaroseriDataAccess.GetAll(), "KaroseriId", "Description");
            ViewBag.MerkBusList = new SelectList(MerkBusDataAccess.GetAll(), "MerkId", "Description");
            ViewBag.TypeBusList = new SelectList(TypeBusDataAccess.GetByMerkBus(model.MerkId), "TypeId", "Description");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            return View(FleetDataAccess.GetById(id));
        }

        // POST: Fleet
        [HttpPost]
        public ActionResult Create(FleetViewModel model)
        {
            return CreateEdit(model);
        }

        [HttpPost]
        public ActionResult Edit(FleetViewModel model)
        {
            return CreateEdit(model);
        }

        [HttpPost]
        public ActionResult DeleteConf(int id)
        {
            if (FleetDataAccess.Delete(id))
            {
                return Json(new { success = true, Message = "Delete Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, Message = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateEdit(FleetViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (FleetDataAccess.Update(model))
                    {
                        return Json(new { success = true, Message = "Success" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, Message = FleetDataAccess.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, Message = "Please complete all required field" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception Ex)
            {
                return Json(new { success = false, Message = Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}