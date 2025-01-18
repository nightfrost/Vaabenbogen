using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using VaabenbogenConsumer.Models;

namespace VaabenbogenConsumer.Helpers
{
    public static class DropdownHelper
    {

        public static List<SelectListItem> VaabenStatusDropdownOptions()
        {
            List<SelectListItem> listOfItems = Enum.GetValues(typeof(VaabenStatus))
                .Cast<VaabenStatus>()
                .Select(status => new SelectListItem
                {
                    Value = ((int)status).ToString(),
                    Text = GetEnumDisplayName(status)
                })
                .ToList();

            listOfItems.Add(new SelectListItem() { });
            return listOfItems;
        }

        public static List<SelectListItem> VaabenTypeDropdownOptions()
        {
            List<SelectListItem> listOfItems = Enum.GetValues(typeof(VaabenType))
                .Cast<VaabenType>()
                .Select(status => new SelectListItem
                {
                    Value = ((int)status).ToString(),
                    Text = GetEnumDisplayName(status)
                })
                .ToList();
            listOfItems.Add(new SelectListItem(){});
            return listOfItems;
        }

        public static List<SelectListItem> LadefunktionDropdownOptions()
        {
            List<SelectListItem> listofItems =  Enum.GetValues(typeof(Ladefunktion))
                .Cast<Ladefunktion>()
                .Select(status => new SelectListItem
                {
                    Value = ((int)status).ToString(),
                    Text = GetEnumDisplayName(status)
                })
                .ToList();

            listofItems.Add(new SelectListItem() { });
            return listofItems;
        }

        private static string GetEnumDisplayName(Enum value)
        {
            var displayAttribute = value.GetType()
                .GetField(value.ToString())
                ?.GetCustomAttribute<DisplayAttribute>();

            return displayAttribute?.Name ?? value.ToString();
        }
    }
}
