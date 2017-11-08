using SimpleFleetManagement.DataAccess;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleFleetManagement.Controllers
{
    public class PartController : Controller
    {
        // GET: Part
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<PartViewModel> model = PartDataAccess.GetAll();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit (int id)
        {
            return View(PartDataAccess.GetById(id));
        }

        [HttpPost]
        public ActionResult Create (PartViewModel model)
        {
            return CreateEdit(model);
        }

        [HttpPost]
        public ActionResult Edit (PartViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult CreateEdit(PartViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (PartDataAccess.Update(model))
                    {
                        return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = PartDataAccess.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Lengkapi!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete (int id)
        {
            return View(PartDataAccess.GetById(id));
        }

        public ActionResult DeleteConfirm (int id)
        {
            if (PartDataAccess.Delete(id))
            {
                return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Error" }, JsonRequestBehavior.AllowGet);
        }
    }
}