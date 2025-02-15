using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.ComponentModel;

namespace VaabenbogenConsumer.Extensions
{
    public static class ViewDataDictionaryExtensions
    {
        public static ViewDataDictionary ToViewDataDictionary(this object values)
        {
            var dictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(values))
            {
                dictionary.Add(property.Name, property.GetValue(values));
            }
            return dictionary;
        }
    }
}
