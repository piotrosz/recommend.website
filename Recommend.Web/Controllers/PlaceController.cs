using System.IO;
using Recommend.Core.DAL;
using Recommend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recommend.UI.Infrastructure;
using WebMatrix.WebData;

namespace Recommend.UI.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlaceController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public ActionResult Add()
        {
            var place = new Place();
            place.Link = "http://www";

            return View(place);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Place place/*, HttpPostedFileBase uploadedFile*/)
        {
            if (!ModelState.IsValid)
            {
                return View(place);
            }
            
            //if (uploadedFile != null && uploadedFile.ContentLength > 0)
            //{
            //    var target = new MemoryStream();
            //    uploadedFile.InputStream.CopyTo(target);
            //    place.PhotoFile = target.ToArray();
            //}

            try
            {
                place.UserId = WebSecurity.GetUserId(User.Identity.Name);
                _unitOfWork.Places.Insert(place);
                _unitOfWork.Save();

                TempData.AddAlertSuccess("Place has been added!");
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
