
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
    public class BookIssueService : IBookIssueService
    {
        private LibraryUnitOfWork _libraryUnitOfWork;

        public BookIssueService(LibraryUnitOfWork libraryUnitOfWork)
        {
            _libraryUnitOfWork = libraryUnitOfWork;
        }

        public void BookIssue(IssueBook bookIssue)
        {
            /**validation check student and book**/

            if (!IsValidStudent(bookIssue))
                throw new SystemException("Student information not available ");
            else if (!IsBookInfoExist(bookIssue))
                throw new SystemException("Book information not available ");
            else if (!IsAvailableCopy(bookIssue))
                throw new SystemException("Book copy not available ");
            else
                bookIssue.BookId = _libraryUnitOfWork.BookIssueRepository.GetBook(bookIssue.Barcode).Id;
               _libraryUnitOfWork.BookIssueRepository.BookIssue(bookIssue);
                BookStockUpdate(bookIssue);
              _libraryUnitOfWork.Save();
        }

        /** validation check **/
        public bool IsValidForBookIssue(IssueBook bookIssue)
        {
            var book = _libraryUnitOfWork.BookIssueRepository.GetBook(bookIssue.Barcode);
            var student = _libraryUnitOfWork.BookIssueRepository.GetStudent(bookIssue.StudentId);
            var availableCopy = _libraryUnitOfWork.BookIssueRepository.GetBook(bookIssue.Barcode).Copycount;

            if (book != null && student != null && availableCopy > 0)
                return true;
            else
                return false;
        }

        public bool IsValidStudent(IssueBook bookIssue)
        {
            var student = _libraryUnitOfWork.BookIssueRepository.GetStudent(bookIssue.StudentId);
            if (student != null)
                return true;
            else
                return false;
        }
        public bool IsBookInfoExist(IssueBook bookIssue)
        {
            var book = _libraryUnitOfWork.BookIssueRepository.GetBook(bookIssue.Barcode);
            if (book != null)
                return true;
            else
                return false;
        }

        public bool IsAvailableCopy(IssueBook bookIssue)
        {
            var availableCopy = _libraryUnitOfWork.BookIssueRepository.GetBook(bookIssue.Barcode).Copycount;
            if (availableCopy > 0)
                return true;
            else
                return false;
        }

        public void BookStockUpdate(IssueBook bookIssue)
        {
            var book = _libraryUnitOfWork.BookIssueRepository.GetBook(bookIssue.Barcode);
            book.Copycount -= 1;
          
        }


    }
}
