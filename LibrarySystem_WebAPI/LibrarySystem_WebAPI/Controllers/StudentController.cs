using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem_WebAPI_Store.IRepository;
using LibrarySystem_WebAPI_Entity.Models;
using LibrarySystem_WebAPI_Store.IServices;

namespace Library_System_CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;
        public StudentController(IStudentService studentService) { _studentService = studentService; }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Student model)
        {
            try
            {
                _studentService.StudentAdd(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };

        }

    }
}
