using System;
using System.Collections.Generic;
using Telerik.Sitefinity.Frontend.Mvc.Models;

namespace SitefinityWebApp.Mvc.Models
{
    public class FilteredSessionsModel
    {
        public ItemViewModel Conference { get; set; }

        public ItemViewModel Speaker { get; set; }

        public IEnumerable<ItemViewModel> Items { get; set; }
    }
}