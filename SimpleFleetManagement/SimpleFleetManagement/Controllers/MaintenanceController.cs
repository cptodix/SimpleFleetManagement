﻿using System;
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
    }
}