

using LibrarySystem_WebAPI_Client.IInputOutputClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem_WebAPI_Client.InputOutputClient
{
    public class ConsoleOutputClient : IOutputClient
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void Write(string format, params object[] values)
        {
            Console.Write(format, values);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine(string format, params object[] values)
        {
            Console.WriteLine(format, values);
        }
    }
}
