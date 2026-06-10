using EmployeeLeaveAPI.Dtos;
using EmployeeLeaveAPI.Models;

namespace EmployeeLeaveAPI.Services
{
    public interface ILeaveRequestService
    {
        LeaveRequest CreateLeaveRequest( LeaveRequestCreateDto dto);

        List<LeaveRequest> GetAllLeaveRequests();

        LeaveRequest? GetLeaveRequestById(int id);
    }
}
