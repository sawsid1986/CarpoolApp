using CarpoolApp.Core.ModelValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Service.Helpers
{
    public class DataAnnotationModelValidator
    {
        public static IModelDictionary Validate(object model)
        {
            IModelDictionary modelState = new ModelDictionary();

            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(model, context, results);

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    foreach(var member in validationResult.MemberNames)
                    {
                        modelState.add(member, validationResult.ErrorMessage);
                    }
                }

                return modelState;
            }

            return null;
        }
    }
}
