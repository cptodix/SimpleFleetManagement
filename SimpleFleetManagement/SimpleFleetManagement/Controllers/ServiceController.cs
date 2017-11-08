using SimpleFleetManagement.DataAccess;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleFleetManagement.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<ServiceViewModel> model = ServiceDataAccess.GetAll();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(ServiceDataAccess.GetById(id));
        }

        [HttpPost]
        public ActionResult Create(ServiceViewModel model)
        {
            return CreateEdit(model);
        }

        [HttpPost]
        public ActionResult Edit(ServiceViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult CreateEdit(ServiceViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ServiceDataAccess.Update(model))
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

        public ActionResult Delete(int id)
        {
            return View(ServiceDataAccess.GetById(id));
        }

        public ActionResult DeleteConfirm(int id)
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