using EmployeeLeaveAPI.Dtos;
using EmployeeLeaveAPI.Models;

namespace EmployeeLeaveAPI.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {

        private readonly List<LeaveRequest> leaveRequests = new();

        public LeaveRequest CreateLeaveRequest(
            LeaveRequestCreateDto dto)
        {
            var leaveRequest = new LeaveRequest
            {
                LeaveRequestId = leaveRequests.Count + 1,

                EmployeeName = dto.EmployeeName,

                EmployeeEmail = dto.EmployeeEmail,

                MobileNumber = dto.MobileNumber,

                LeaveType = dto.LeaveType,

                StartDate = dto.StartDate,

                EndDate = dto.EndDate,

                Reason = dto.Reason,

                TotalDays =
                    (dto.EndDate - dto.StartDate).Days + 1,

                Status = "Pending",

                CreatedOn = DateTime.Now
            };

            leaveRequests.Add(leaveRequest);

            return leaveRequest;
        }

        public List<LeaveRequest> GetAllLeaveRequests()
        {
            return leaveRequests;
        }

        public LeaveRequest? GetLeaveRequestById(int id)
        {
            return leaveRequests.FirstOrDefault(
                x => x.LeaveRequestId == id);
        }
    }
}
