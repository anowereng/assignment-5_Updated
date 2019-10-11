using LibrarySystem_WebAPI_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_WebAPI_Store.IRepository
{
    public interface IBookIssueRepository
    {
        void BookIssue(IssueBook issueBook);
        Book GetBook(string barcode);
        Student GetStudent(int studentid);
        void SaveChanges();
    }
}
