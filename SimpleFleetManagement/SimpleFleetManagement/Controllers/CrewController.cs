using SimpleFleetManagement.DataAccess;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleFleetManagement.Controllers
{
    public class CrewController : Controller
    {
        // GET: Crew
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<CrewViewModel> model = CrewDataAccess.GetAll();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(CrewDataAccess.GetById(id));
        }

        public ActionResult Delete(int id)
        {
            return View(CrewDataAccess.GetById(id));
        }

        // POST: Crew
        [HttpPost]
        public ActionResult Create(CrewViewModel model)
        {
            return CreateEdit(model);
        }

        [HttpPost]
        public ActionResult Edit(CrewViewModel model)
        {
            return CreateEdit(model);
        }

        [HttpPost]
        public ActionResult DeleteConf(int id)
        {
            if (CrewDataAccess.Delete(id))
            {
                return Json(new { success = true, Message = "Delete Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, Message = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateEdit(CrewViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (CrewDataAccess.Update(model))
                    {
                        return Json(new { success = true, Message = "Success" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, Message = CrewDataAccess.Message }, JsonRequestBehavior.AllowGet);
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