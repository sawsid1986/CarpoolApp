using CarpoolApp.Core.ModelValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace CarpoolApp.Web.Helpers
{
    public static class ModelStateHelper
    {
        public static ModelStateDictionary ToModelStateDictionary(this IModelDictionary _modelState)
        {
            ModelStateDictionary dictionary = new ModelStateDictionary();

            foreach(var item in _modelState)
            {
                dictionary.AddModelError(item.Key, item.Value);
            }

            return dictionary;
        }
    }
}