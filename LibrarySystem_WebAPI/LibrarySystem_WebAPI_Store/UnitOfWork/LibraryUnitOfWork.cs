using LibrarySystem_WebAPI_Store.IRepository;
using LibrarySystem_WebAPI_Store.Repository;
using LibrarySystem_WebAPI_Store.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem_WebAPI_Store.UnitOfWork
{
    public class LibraryUnitOfWork : ILibraryUnitOfWork
    {
        private LibrarySystemContext _context;

        public IBookRepository BookRepository { get; private set; }
        public IStudentRepository StudentRepository { get; private set; }
        public IBookIssueRepository BookIssueRepository { get; private set; }
        public IBookFineRepository BookFineRepository { get; private set; }
        public IBookReturnRepository BookReturnRepository { get; private set; }

        public LibraryUnitOfWork(string connectionString, string migrationAssemblyName)
        {
            _context = new LibrarySystemContext(connectionString, migrationAssemblyName);

            BookRepository = new BookRepository(_context);
            StudentRepository = new StudentRepository(_context);
            BookIssueRepository = new BookIssueRepository(_context);
            BookFineRepository = new BookFineRepository(_context);
            BookReturnRepository = new BookReturnRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}