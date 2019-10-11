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
    public class BookFineController : ControllerBase
    {
        private IBookFineService _bookFineService;

        public BookFineController(IBookFineService bookFineService) { _bookFineService = bookFineService; }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Student model)
        {
            try
            {
                _bookFineService.ReceiveFineAmount(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<double> Get(int id)
        {
            try
            {
               var finamount= _bookFineService.GetFineAmount(id);
                return Ok(finamount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }
    }
}
