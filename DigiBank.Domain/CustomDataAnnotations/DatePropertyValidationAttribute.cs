using System.ComponentModel.DataAnnotations;

namespace DigiBank.Domain.CustomDataAnnotations
{
    public class DatePropertyValidationAttribute : ValidationAttribute
    {
        public DatePropertyValidationAttribute()
        {
        }

        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }
    }
}
