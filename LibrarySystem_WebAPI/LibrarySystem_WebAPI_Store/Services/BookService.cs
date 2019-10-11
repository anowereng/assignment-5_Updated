
using LibrarySystem_WebAPI_Store.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem_WebAPI_Store.IServices;
using LibrarySystem_WebAPI_Store.IRepository;
using LibrarySystem_WebAPI_Entity.Models;
using LibrarySystem_WebAPI_Store.UnitOfWork;

namespace LibrarySystem_WebAPI_Store.Services
{
    public class BookService : IBookService
    {
        private LibraryUnitOfWork _libraryUnitOfWork;

        public BookService(LibraryUnitOfWork libraryUnitOfWork)
        {
            _libraryUnitOfWork = libraryUnitOfWork;
        }


        public void BookAdd(Book book)
        {
            _libraryUnitOfWork.BookRepository.BookAdd(book);
            _libraryUnitOfWork.Save();
        }

    }
}
