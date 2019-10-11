using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem_WebAPI_Store.IRepository;
using LibrarySystem_WebAPI_Entity.Models;
using LibrarySystem_WebAPI_Store.Interfaces;

namespace Library_System_CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReturnController : ControllerBase
    {
        private IBookReturnService _bookReturnService;

        public BookReturnController(IBookReturnService service) { _bookReturnService = service; }

        [HttpPost]
        public ActionResult Post([FromBody] ReturnBook model)
        {
            try
            {
                _bookReturnService.BookReturn(model);
                return Ok();
            }
           catch ( Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
