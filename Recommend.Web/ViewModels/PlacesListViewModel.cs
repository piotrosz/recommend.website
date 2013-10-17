using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recommend.Core.Models;

namespace Recommend.UI.ViewModels
{
    public class PlacesListViewModel
    {
        public PlacesListViewModel()
        {
            PagingInfo = new PagingInfo();
        }

        public Place FeaturedPlace { get; set; }
        public List<Place> Places { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}