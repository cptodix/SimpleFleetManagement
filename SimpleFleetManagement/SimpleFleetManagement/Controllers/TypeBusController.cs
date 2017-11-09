using SimpleFleetManagement.DataAccess;
using SimpleFleetManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleFleetManagement.Controllers
{
    public class TypeBusController : Controller
    {
        // GET: Type
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<TypeBusViewModel> model = TypeBusDataAccess.GetAll();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.MerkBusList = new SelectList(MerkBusDataAccess.GetAll(), "MerkId", "Description");
            return View();
        }

        public ActionResult Edit (int id)
        {
            ViewBag.MerkBusList = new SelectList(MerkBusDataAccess.GetAll(), "MerkId", "Description");
            return View(TypeBusDataAccess.GetById(id));
        }

        [HttpPost]
        public ActionResult Create(TypeBusViewModel model)
        {
            return CreateEdit(model);
        }

        [HttpPost]
        public ActionResult Edit(TypeBusViewModel model)
        {
            return CreateEdit(model);
        }

        public ActionResult CreateEdit(TypeBusViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (TypeBusDataAccess.Update(model))
                    {
                        return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = TypeBusDataAccess.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Lengkapi isi form nya" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            return View(TypeBusDataAccess.GetById(id));
        }

        public ActionResult DeleteConfirm(int id)
        {
            if (TypeBusDataAccess.Delete(id))
            {
                return Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = TypeBusDataAccess.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, message = "Error :p" }, JsonRequestBehavior.AllowGet);

        }
    }
}