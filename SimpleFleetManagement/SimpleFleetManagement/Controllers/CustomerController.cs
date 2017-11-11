using SimpleFleetManagement.DataAccess;
using SimpleFleetManagement.ViewModel;
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
            List<CustomerViewModel> model = CustomerDataAccess.GetAll();
            return View(model);
        }
        
        public ActionResult GetByCustomerId(string customerid)
        {
            CustomerViewModel model = CustomerDataAccess.GetByCustomerId(customerid);
            if (model != null)
            {
                return Json(new { success = true, data = model }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, JsonRequestBehavior.AllowGet }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetByFilter(string filterstring)
        {
            return View(CustomerDataAccess.GetByFilter(filterstring));
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(CustomerDataAccess.GetById(id));
        }

        public ActionResult Delete(int id)
        {
            return View(CustomerDataAccess.GetById(id));
        }

        // POST: Customer
        [HttpPost]
        public ActionResult Create(CustomerViewModel model)
        {
            return CreateEdit(model);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel model)
        {
            return CreateEdit(model);
        }

        [HttpPost]
        public ActionResult DeleteConf(int id)
        {
            if (CustomerDataAccess.Delete(id))
            {
                return Json(new { success = true, Message = "Delete Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, Message = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateEdit(CustomerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (CustomerDataAccess.Update(model))
                    {
                        return Json(new { success = true, Message = "Success" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, Message = CustomerDataAccess.Message }, JsonRequestBehavior.AllowGet);
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