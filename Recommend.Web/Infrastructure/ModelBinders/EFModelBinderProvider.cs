using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recommend.UI.Infrastructure.ModelBinders
{
    public class EFModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            return modelType == typeof(DbGeography) ? new DbGeographyModelBinder() : null;
        }
    }
}