using Cw5.Services;
using Cw5.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cw5.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase {
        private readonly IStudentDbService _dbService;

        public EnrollmentsController(IStudentDbService dbService) {
            _dbService = dbService;
        }

        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request) {
            var response = _dbService.EnrollStudent(request);
            if (response == null) {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
