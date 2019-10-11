using LibrarySystem_WebAPI_Client.IInputOutputClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem_WebAPI_Client.InputOutputClient
{
    public class ConsoleInputClient : IInputClient
    {
        public string ReadLine()
        {
           return  Console.ReadLine();
        }
    }
}
