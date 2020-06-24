using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NotatnikMechanika.Core.Model
{
    public static class ModelValidationBase
    {
        public static bool IsModelValid<ResponseModel>(this object model, out Response<ResponseModel> errorResponse)
        {
            List<string> errors = new List<string>();
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
            errorResponse = Response<ResponseModel>.GetBadModelState(errors);
            return isValid;
        }
    }
}
