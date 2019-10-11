
using LibrarySystem_WebAPI_Store.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem_WebAPI_Entity.Models;
using LibrarySystem_WebAPI_Store.IServices;
using LibrarySystem_WebAPI_Store.IRepository;
using LibrarySystem_WebAPI_Store.UnitOfWork;

namespace LibrarySystem_WebAPI_Store.Services
{
    public class StudentService : IStudentService
    {
        private LibraryUnitOfWork _libraryUnitOfWork;

        public StudentService(LibraryUnitOfWork libraryUnitOfWork)
        {
            _libraryUnitOfWork = libraryUnitOfWork;
        }
        public void StudentAdd(Student student)
        {
            _libraryUnitOfWork.StudentRepository.StudentAdd(student);
            _libraryUnitOfWork.Save();
        }
    }
}
