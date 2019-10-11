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
    public class StudentRepository : IStudentRepository
    {
        private LibrarySystemContext _context;
        public StudentRepository(LibrarySystemContext context) { _context = context; }
        public void StudentAdd(Student model)
        {
            _context.Add(model);
        }
        public Student GetStudent(int StudentId)
        {
            var data = _context.Student.Where(x => x.Id == StudentId).FirstOrDefault();
            return data;
        }

    }
}
