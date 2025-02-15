using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using VaabenbogenConsumer.Data;
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

        public static async Task<List<SelectListItem>> IndskriverDropdownOptions(VaabenBogenContext _context)
        {
            List<SelectListItem> listOfItems = await _context.Virksomheder
                .Select(virks => new SelectListItem
                {
                    Text = virks.Navn,
                    Value = virks.Cvr
                }).ToListAsync();

            listOfItems.AddRange(await _context.Jaegere
                .Select(jaegers => new SelectListItem
                {
                    Text = jaegers.Fornavn,
                    Value = jaegers.Cpr
                }).ToListAsync());

            return listOfItems;
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
