using LibrarySystem_WebAPI_Store;
using LibrarySystem_WebAPI_Store.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem_WebAPI_Entity.Models;
using LibrarySystem_WebAPI_Store.IRepository;

namespace LibrarySystem_WebAPI_Store.Repository
{
    public class BookRepository : IBookRepository
    {
        private LibrarySystemContext _context;
        public BookRepository(LibrarySystemContext context) { _context = context; }

        public void BookAdd(Book model)
        {
            _context.Add(model);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Book.ToList();
        }

        public Book GetBook(string barcode)
        {
            return _context.Book.Find(barcode);
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChange() { _context.SaveChanges(); }
    }
}
