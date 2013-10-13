using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recommend.Core.DAL;
using Recommend.Core.Models;

namespace Recommend.UI.Controllers
{
    public class RecommendationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecommendationController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public ActionResult Add()
        {
            return View(new Recommendation());
        }
    }
}
