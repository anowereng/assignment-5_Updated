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
    public class BookFineRepository : IBookFineRepository
    {
        private LibrarySystemContext _context;
        public BookFineRepository(LibrarySystemContext context) { _context = context; }

        public Student GetStudentForFineAmount(int studentid)
        {
            return _context.Student.Find(studentid);
        }

        public void ReceiveFineAmount(int amount)
        {
            _context.Add(amount);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
