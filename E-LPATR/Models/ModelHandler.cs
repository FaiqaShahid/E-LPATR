using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LPATR.Models
{
    public static class ModelHandler
    {
        public static List<SelectListItem> ToSelectListItems(this IEnumerable<IListable> entitiesList)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var item in entitiesList)
            {
                listItems.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            return listItems;
        }

    }
}