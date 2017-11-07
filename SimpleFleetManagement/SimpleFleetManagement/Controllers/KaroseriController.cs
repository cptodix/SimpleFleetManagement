using SimpleFleetManagement.DataAccess;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleFleetManagement.Controllers
{
    public class KaroseriController : Controller
    {
        // GET: Karoseri
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<KaroseriViewModel> model = KaroseriDataAccess.GetAll();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(KaroseriDataAccess.GetById(id));
        }

        public ActionResult Delete(int id)
        {
            return View(KaroseriDataAccess.GetById(id));
        }

        // POST: Karoseri
        [HttpPost]
        public ActionResult Create(KaroseriViewModel model)
        {
            return CreateEdit(model);
        }

        [HttpPost]
        public ActionResult Edit(KaroseriViewModel model)
        {
            return CreateEdit(model);
        }

        [HttpPost]
        public ActionResult DeleteConf(int id)
        {
            if (KaroseriDataAccess.Delete(id))
            {
                return Json(new { success = true, Message = "Delete Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, Message = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateEdit(KaroseriViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (KaroseriDataAccess.Update(model))
                    {
                        return Json(new { success = true, Message = "Success" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, Message = KaroseriDataAccess.Message }, JsonRequestBehavior.AllowGet);
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