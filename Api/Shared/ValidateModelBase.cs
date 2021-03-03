using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NotatnikMechanika.Shared
{
    public abstract class ValidateModelBase : IDataErrorInfo
    {
        // check for general model error    
        public string Error => null;

        public bool IsValid => Validator.TryValidateObject(this, new ValidationContext(this), new List<ValidationResult>());

        // check for property errors    
        public string this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();
                object value = GetType().GetProperty(columnName).GetValue(this);
                if (Validator.TryValidateProperty(
                        value,
                        new ValidationContext(this)
                        {
                            MemberName = columnName
                        },
                        validationResults))
                {
                    return null;
                }
                return validationResults[0].ErrorMessage;
            }
        }
    }
}
