using LibrarySystem_WebAPI_Client.IModelGateway;
using LibrarySystem_WebAPI_Client.ModelGateway;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem_WebAPI_Client.IServiceClient
{
    public interface IBookFineServiceClient
    {
        void GetFineAmount();
        void PostFineAmount();
    }
}
