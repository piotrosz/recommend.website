using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recommend.UI.Infrastructure
{
    public static class TempDataExtensions
    {
        public static void AddAlertSuccess(this TempDataDictionary tempData, string alert)
        {
            tempData["AlertSuccess"] = alert;
        }

        public static void AddAlertWarning(this TempDataDictionary tempData, string alert)
        {
            tempData["AlertWarning"] = alert;
        }

        public static void AddAlertInfo(this TempDataDictionary tempData, string alert)
        {
            tempData["AlertInfo"] = alert;
        }

        public static void AddAlertDanger(this TempDataDictionary tempData, string alert)
        {
            tempData["AlertDanger"] = alert;
        }
    }
}