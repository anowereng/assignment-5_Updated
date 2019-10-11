using LibrarySystem_WebAPI_Store.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem_WebAPI_Store.UnitOfWork
{
    public interface ILibraryUnitOfWork
    {
         IBookRepository BookRepository { get;  }
         IStudentRepository StudentRepository { get;  }
         IBookIssueRepository BookIssueRepository { get; }
         IBookFineRepository BookFineRepository { get; }
         IBookReturnRepository BookReturnRepository { get; }
         void Save();
    }
}
