using LibrarySystem_WebAPI_Client.IInputOutputClient;
using LibrarySystem_WebAPI_Client.IModelConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem_WebAPI_Client.ModelConsole
{
    public class ConsoleClient : IConsoleClient
    {
        private IOutputClient _OutputClient; private IInputClient _InputClient;
        public ConsoleClient(IOutputClient OutputClient, IInputClient InputClient)
        {
            _OutputClient = OutputClient; _InputClient = InputClient;
        }

        public void InitialMessage()
        {
            _OutputClient.WriteLine("================================");
        }
        public void OutputMessage(string data)
        {
             _OutputClient.Write($"Please enter { data } :");
        }
        public void OutputMessageBlank(string data)
        {
            _OutputClient.WriteLine(data);
        }
        public string ClientInput()
        {
            return _InputClient.ReadLine();
        }
     
    }
}
