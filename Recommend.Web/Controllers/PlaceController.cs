using System.IO;
using Recommend.Core.DAL;
using Recommend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recommend.UI.Infrastructure;
using Recommend.UI.Infrastructure.ModelBinders;
using Recommend.UI.ViewModels;
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
        public ActionResult Add(Place place/*, HttpPostedFileBase uploadedFile*/, [ModelBinder(typeof(UserIdBinder))] int userId)
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
                place.UserId = userId;
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

        public ActionResult List(int page = 0)
        {
            if (page < 0)
            {
                throw new ArgumentException("Page argument must grater than 0");
            }

            var result = new PlacesListViewModel();
            result.PagingInfo.CurrentPage = page;
            result.PagingInfo.ItemsPerPage = 6;
            result.PagingInfo.TotalItems = _unitOfWork.Places.List().Count();

            result.FeaturedPlace = _unitOfWork.Places.List().OrderByDescending(p => p.Id).FirstOrDefault();

            var places = _unitOfWork.Places.List()
                .Where(p => p.Id != result.FeaturedPlace.Id)
                .OrderByDescending(x => x.Id)
                .Skip(page * result.PagingInfo.ItemsPerPage)
                .Take(result.PagingInfo.ItemsPerPage).ToList();

            result.Places = places;

            return View(result);
        }

    }
}
