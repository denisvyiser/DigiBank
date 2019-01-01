using System.ComponentModel.DataAnnotations;

namespace DigiBank.Domain.CustomDataAnnotations
{
    public class PropertyValidationAttribute : ValidationAttribute
    {
        public PropertyValidationAttribute()
        {

        }

        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }
    }
}
