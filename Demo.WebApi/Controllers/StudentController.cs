using Demo.Application;
using Demo.Dtos.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Mvc.Controllers
{
    [Route("api/student")]
    public class StudentController : Controller
    {
        private readonly StudentServices _studentServices;

        public StudentController(StudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        /// <summary>
        /// 获取所有学生信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("students")]
        public async Task<List<StudentDto>> GetStudents()
        {
            return await _studentServices.GetStudents();
        }

        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task SetStudents([FromBody]CreateStudentRequest model)
        {
            await _studentServices.SetStudents(model.StudentDtos);
        }

    }
}
