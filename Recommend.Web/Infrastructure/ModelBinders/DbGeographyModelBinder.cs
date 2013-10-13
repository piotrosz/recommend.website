using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

using IMvcModelBinder = System.Web.Mvc.IModelBinder;
using MvcModelBindingContext = System.Web.Mvc.ModelBindingContext;


namespace Recommend.UI.Infrastructure.ModelBinders
{
    public class DbGeographyModelBinder : IMvcModelBinder
    {
        public object BindModel(ControllerContext controllerContext, MvcModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            return BindModelImpl(valueProviderResult != null ? valueProviderResult.AttemptedValue : null);
        }

        private DbGeography BindModelImpl(string value)
        {
            if (value == null)
            {
                return null;
            }

            string[] latLongStr = value.Split(',');

            // TODO: More error handling here, what if there is more than 2 pieces or less than 2?
            //       Are we supposed to populate ModelState with errors here if we can't conver the value to a point?

            string point = string.Format("POINT ({0} {1})", latLongStr[1], latLongStr[0]);
            
            //4326 format puts LONGITUDE first then LATITUDE
            DbGeography result = DbGeography.FromText(point, 4326);
            
            return result;
        }
    }
}