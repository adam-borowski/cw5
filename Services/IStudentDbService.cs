using Cw5.DTOs.Requests;
using Cw5.Models;

namespace Cw5.Services
{
    public interface IStudentDbService
    {
        Enrollment EnrollStudent(EnrollStudentRequest request);
        Enrollment PromoteStudents(PromoteStudentRequest request);
    }
}