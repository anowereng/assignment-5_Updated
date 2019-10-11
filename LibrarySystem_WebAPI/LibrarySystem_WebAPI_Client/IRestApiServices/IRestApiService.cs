using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem_WebAPI_Client.IRestApiServices
{
   public interface IRestApiService
    {
        void POST(object model, string apiController);
        IEnumerable<Object> GetAll();
        object  GetById(int id , string apiController);
        void  Delete(int id);
        void  Put(int id , object model, string apiController);
    }
}
