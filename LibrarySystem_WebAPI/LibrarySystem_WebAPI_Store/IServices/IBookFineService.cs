using LibrarySystem_WebAPI_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_WebAPI_Store.IServices
{
    public interface IBookFineService
    {
        double GetFineAmount(int id);
        void ReceiveFineAmount(int id , Student model);
    }
}
