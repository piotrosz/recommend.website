using Recommend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Recommend.UI.Infrastructure.ModelBinders
{
    public class UserIdBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return WebSecurity.CurrentUserId;
        }
    }
}