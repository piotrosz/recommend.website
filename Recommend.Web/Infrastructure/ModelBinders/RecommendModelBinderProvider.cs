using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recommend.UI.Infrastructure.ModelBinders
{
    public class RecommendModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (modelType == typeof (DbGeography))
            {
                return new DbGeographyModelBinder();
            }

            return null;
        }
    }
}