using Demo.Application;
using Demo.Dtos.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Mvc.Controllers
{
    [Route("{Controller}")]
    public class StudentController : Controller
    {
        private readonly StudentServices _studentServices;

        public StudentController(StudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        [HttpGet("students")]
        public async Task<List<StudentDto>> GetStudents()
        {
            return await _studentServices.GetStudents();
        }

        [HttpPost("list")]
        public async Task SetStudents(List<StudentDto> models)
        {
            await _studentServices.SetStudents(models);
        }

    }
}
