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
    public class BookIssueController : ControllerBase
    {
        private IBookIssueService _bookIssueService;

        public BookIssueController(IBookIssueService service) { _bookIssueService = service; }

        [HttpPost]
        public ActionResult Post([FromBody] IssueBook model)
        {
            try
            {
                _bookIssueService.BookIssue(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            };
            
        }
    }
}
