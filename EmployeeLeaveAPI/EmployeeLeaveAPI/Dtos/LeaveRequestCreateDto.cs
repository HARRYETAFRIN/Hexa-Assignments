using System.ComponentModel.DataAnnotations;
using EmployeeLeaveAPI.Validation;
namespace EmployeeLeaveAPI.Dtos
{
    public class LeaveRequestCreateDto
    {
        [Required(ErrorMessage = "Employee Name is required.")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Employee Name must be between 3 and 100 characters.")]
        public string EmployeeName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Employee Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string EmployeeEmail { get; set; } = string.Empty;


        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^[6-9]\d{9}$",
            ErrorMessage = "Mobile Number must be a valid 10 digit Indian mobile number.")]
        public string MobileNumber { get; set; } = string.Empty;


        [Required(ErrorMessage = "Leave Type is required.")]
        [ValidLeaveType(ErrorMessage =
            "Leave Type must be Sick, Casual or Earned.")]
        public string LeaveType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start Date is required.")]
        [FutureDate(ErrorMessage = "Start Date must be a future date.")]
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage = "End Date is required.")]
        [FutureDate(ErrorMessage = "End Date must be a future date.")]
        public DateTime EndDate { get; set; }


        [Required(ErrorMessage = "Reason is required.")]
        [StringLength(250, MinimumLength = 10,
            ErrorMessage = "Reason must be between 10 and 250 characters.")]
        public string Reason { get; set; } = string.Empty;
    }
}
