using LibrarySystem_WebAPI_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem_WebAPI_Store.Interfaces
{
    public interface IBookReturnService
    {
        void BookReturn(ReturnBook bookReturn);
        bool IsValidBookStudentData(ReturnBook bookReturn);
        bool IsValidIssueData(ReturnBook bookReturn);
        void UpdateFineAmount(ReturnBook bookReturn);
        float GetFineAmount(ReturnBook model);
        void UpdateBookStock(string barcode);


    }
}
