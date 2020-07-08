using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.Model
{
    public static class ModelValidationBase
    {
        public static bool IsModelValid(this object model, out Response errorResponse)
        {
            bool isValid = model.IsValid(out List<string> errors);
            errorResponse = BadRequestResponse(errors);
            return isValid;
        }

        public static bool IsModelValid<ResponseModel>(this object model, out Response<ResponseModel> errorResponse)
        {
            bool isValid = model.IsValid(out List<string> errors);
            errorResponse = BadRequestResponse<ResponseModel>(errors);
            return isValid;
        }

        private static bool IsValid(this object model, out List<string> errors)
        {
            errors = new List<string>();
            bool isValid = true;
            foreach (PropertyInfo i in model.GetType().GetProperties())
            {
                foreach (ValidationAttribute a in i.GetCustomAttributes<ValidationAttribute>())
                {
                    if (!a.IsValid(i.GetValue(model)))
                    {
                        errors.Add(a.ErrorMessage);
                        isValid = false;
                    }
                }
            }
            return isValid;
        }
    }
}
