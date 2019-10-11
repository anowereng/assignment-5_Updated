
using LibrarySystem_WebAPI_Store.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem_WebAPI_Entity.Models;
using LibrarySystem_WebAPI_Store.IRepository;
using LibrarySystem_WebAPI_Store.UnitOfWork;

namespace LibrarySystem_WebAPI_Store.Services
{
    public class BookReturnService : IBookReturnService
    {
        private LibraryUnitOfWork _libraryUnitOfWork;

        public BookReturnService(LibraryUnitOfWork libraryUnitOfWork)
        {
            _libraryUnitOfWork = libraryUnitOfWork;
        }

        public void BookReturn(ReturnBook bookReturn)
        {

            if (IsValidBookStudentData(bookReturn) && IsValidIssueData(bookReturn))
            {
                bookReturn.BookId= _libraryUnitOfWork.BookReturnRepository.GetBook(bookReturn.Barcode).Id;
                _libraryUnitOfWork.BookReturnRepository.BookReturn(bookReturn);
                 UpdateFineAmount(bookReturn); UpdateBookStock(bookReturn.Barcode);
                _libraryUnitOfWork.Save();
            }
           
        }

        /** validation check **/
        public bool IsValidBookStudentData(ReturnBook bookReturn)
        {
            var book = _libraryUnitOfWork.BookReturnRepository.GetBook(bookReturn.Barcode);
            var student = _libraryUnitOfWork.BookReturnRepository.GetStudent(bookReturn.StudentId);
            var result = book != null || student != null ? true : false;
            return result;
        }

        public bool IsValidIssueData(ReturnBook bookReturn)
        {
            var issueInfoBybook = _libraryUnitOfWork.BookReturnRepository.GetIssueInfoBook(bookReturn.Barcode);
            var issueInfoByStudent = _libraryUnitOfWork.BookReturnRepository.GetIssueInfoStudent(bookReturn.StudentId);

            var result = issueInfoBybook != null || issueInfoByStudent != null ? true : false;
            return result;
        }


        public void UpdateFineAmount(ReturnBook bookReturn)
        {
            _libraryUnitOfWork.BookReturnRepository.GetStudent(bookReturn.StudentId).FineAmount  =  GetFineAmount(bookReturn);
        }

        public float GetFineAmount(ReturnBook model)
        {
            var issueDate = _libraryUnitOfWork.BookReturnRepository.GetIssueInfoBook(model.Barcode).IssueDate;
            float fineAmount = 0;
            TimeSpan totalDays = (DateTime.Now - issueDate);
            var Days = 7;
            if (totalDays.Days > Days)
            {
                double delayTotalDays = totalDays.Days - Days;
                double fine = delayTotalDays * 10;
                //fineAmount = fineAmount > 7 || fineAmount > 10 ? delayTotalDays * 10 : delayTotalDays * 20;
                fineAmount = (float)fine;
            }
            return fineAmount;
        }

        public void UpdateBookStock(string barcode)
        {
            var bookStockQty = _libraryUnitOfWork.BookReturnRepository.GetBook(barcode);
            bookStockQty.Copycount += 1;
        }


    }
}
