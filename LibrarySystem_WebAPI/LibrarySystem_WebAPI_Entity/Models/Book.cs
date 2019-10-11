using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibrarySystem_WebAPI_Entity.Models
{
    public class Book
    {
        public int Id { get; set; }
        //public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Barcode { get; set; }
        public int Copycount { get; set; }

    }
}
