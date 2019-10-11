
using LibrarySystem_WebAPI_Entity.Models;
using LibrarySystem_WebAPI_Store.Interfaces;
using LibrarySystem_WebAPI_Store.IRepository;
using LibrarySystem_WebAPI_Store.IServices;
using LibrarySystem_WebAPI_Store.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_WebAPI_Store.Services
{
    public class BookFineService : IBookFineService
    {
        private LibraryUnitOfWork _libraryUnitOfWork;

        public BookFineService(LibraryUnitOfWork libraryUnitOfWork)
        {
            _libraryUnitOfWork = libraryUnitOfWork; 
        }
        public double GetFineAmount(int id)
        {
            var fineamount = _libraryUnitOfWork.BookFineRepository.GetStudentForFineAmount(id).FineAmount;
            return fineamount;
        }

        public void ReceiveFineAmount(int id , Student model)
        {
            var student = _libraryUnitOfWork.BookFineRepository.GetStudentForFineAmount(id);
            var recvAmount = model.FineAmount;
            var dueamount = (student.FineAmount - recvAmount);

            if (recvAmount > student.FineAmount)
                model.FineAmount = 0;
            else
            student.FineAmount = dueamount;

            _libraryUnitOfWork.Save();
        }
    }
}
