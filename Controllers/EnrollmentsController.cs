using Cw5.Services;
using Cw5.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Cw5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase {
        private readonly IStudentDbService _dbService;

        public EnrollmentsController(IStudentDbService dbService) {
            _dbService = dbService;
        }

        [Route("api/enrollments")]
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request) {
            var response = _dbService.EnrollStudent(request);
            if (response == null) {
                return BadRequest();
            }
            return Created("http://localhost:5001", response);
        }

        [Route("api/enrollments/promotions")]
        [HttpPost]
        public IActionResult StudentPromotions(PromoteStudentRequest request) {
            var response = _dbService.PromoteStudents(request);
            if (response == null) {
                return NotFound();
            }

            return Created("http://localhost:5001", response);
        }
    }
}
