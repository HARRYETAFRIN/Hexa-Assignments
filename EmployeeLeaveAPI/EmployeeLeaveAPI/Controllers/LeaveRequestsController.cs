using EmployeeLeaveAPI.Dtos;
using EmployeeLeaveAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestsController(
            ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [HttpPost]
        public IActionResult CreateLeaveRequest(
            LeaveRequestCreateDto dto)
        {
            try
            {
                var leaveRequest =
                    _leaveRequestService.CreateLeaveRequest(dto);

                return Ok(leaveRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllLeaveRequests()
        {
            var leaveRequests =
                _leaveRequestService.GetAllLeaveRequests();

            return Ok(leaveRequests);
        }

        [HttpGet("{id}")]
        public IActionResult GetLeaveRequestById(int id)
        {
            var leaveRequest =
                _leaveRequestService.GetLeaveRequestById(id);

            if (leaveRequest == null)
            {
                return NotFound(
                    $"Leave Request with Id {id} not found.");
            }

            return Ok(leaveRequest);
        }
    }
}