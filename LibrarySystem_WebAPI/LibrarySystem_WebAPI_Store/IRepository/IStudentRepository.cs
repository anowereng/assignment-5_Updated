using LibrarySystem_WebAPI_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_WebAPI_Store.IRepository
{
    public interface IStudentRepository
    {
        void StudentAdd(Student model);
        Student GetStudent(int studentId);
    }
}
