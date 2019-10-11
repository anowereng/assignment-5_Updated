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
    public class BookIssueRepository : IBookIssueRepository
    {
        private LibrarySystemContext _context;
        public BookIssueRepository(LibrarySystemContext context) { _context = context; }

        public void BookIssue(IssueBook issueBook)
        {
            _context.Add(issueBook);
        }

        public Book GetBook(string barcode)
        {
            return _context.Book.Where(x => x.Barcode == barcode).FirstOrDefault();
        }
        public Student GetStudent(int studentid)
        {
            return _context.Student.Find(studentid);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
