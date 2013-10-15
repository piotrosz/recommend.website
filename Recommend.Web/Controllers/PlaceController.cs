﻿using Recommend.Core.DAL;
using Recommend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recommend.UI.Controllers
{
    public class PlaceController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public PlaceController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Place place)
        {
            try
            {
                _unitOfWork.Places.Insert(place);
                _unitOfWork.Save();

                TempData["SuccessMessage"] = "Place has been added!";

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
            }
            
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View();
        }

    }
}
