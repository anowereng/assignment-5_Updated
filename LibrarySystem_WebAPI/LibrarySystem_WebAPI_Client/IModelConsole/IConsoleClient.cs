using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem_WebAPI_Client.IModelConsole
{
    public interface IConsoleClient 
    {
        void InitialMessage();
        void OutputMessage(string data);
        string ClientInput();
        void OutputMessageBlank(string data);

        
    }
}
