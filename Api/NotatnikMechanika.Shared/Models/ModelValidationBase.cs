using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NotatnikMechanika.Shared.Models
{
    public static class ModelValidationBase
    {
        public static bool IsModelValid(this object model, out string errorMessage)
        {
            foreach (PropertyInfo i in model.GetType().GetProperties())
            {
                foreach (ValidationAttribute a in i.GetCustomAttributes<ValidationAttribute>())
                {
                    if (!a.IsValid(i.GetValue(model)))
                    {
                        errorMessage = a.ErrorMessage;
                        return false;
                    }
                }
            }
            errorMessage = "";
            return true;
        }
    }
}
