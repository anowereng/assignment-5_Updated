using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibrarySystem_WebAPI_Entity.IModels
{
    public interface IBook
    {
         int Id { get; set; }
        //public int BookId { get; set; }
         string Title { get; set; }
         string Author { get; set; }
         string Edition { get; set; }
         string Barcode { get; set; }
         int Copycount { get; set; }

    }
}
