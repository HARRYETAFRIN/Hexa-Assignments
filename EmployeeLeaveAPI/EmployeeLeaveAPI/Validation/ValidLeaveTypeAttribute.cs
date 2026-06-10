using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveAPI.Validation
{
    public class ValidLeaveTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid( object? value,ValidationContext validationContext)
        {
            var allowedTypes = new[]
            {
                "Sick",
                "Casual",
                "Earned"
            };

            if (value == null ||
                !allowedTypes.Contains(value.ToString()))
            {
                return new ValidationResult(
                    "Leave Type must be Sick, Casual or Earned");
            }

            return ValidationResult.Success;
        }
    }
}
