using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem_WebAPI_Store.IRepository;
using LibrarySystem_WebAPI_Entity.Models;
using LibrarySystem_WebAPI_Store.IServices;

namespace LibrarySystem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        public BookController(IBookService bookService) { _bookService = bookService; }

        [HttpPost]
        public ActionResult Post([FromBody] Book model)
        {
            try
            {
                _bookService.BookAdd(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }
        

    }
}
