using Demo.Application;
using Demo.Dtos.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentServices _studentServices;

        public HomeController(ILogger<HomeController> logger, StudentServices studentServices)
        {
            _logger = logger;
            _studentServices = studentServices;
        }

        public IActionResult Index()
        {
            return View();
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
