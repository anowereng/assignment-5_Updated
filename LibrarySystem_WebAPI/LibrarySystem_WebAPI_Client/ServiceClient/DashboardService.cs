using LibrarySystem_WebAPI_Client.IModelConsole;
using LibrarySystem_WebAPI_Client.IServiceClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem_WebAPI_Client.ServiceClient
{
    public class DashboardService  : IDashboardService
    {
        private IConsoleClient _IConsoleClient;

        public DashboardService(IConsoleClient IConsoleClient)
        {
            _IConsoleClient = IConsoleClient;
        }

        public int InitialDashboardMessage()
        {
            _IConsoleClient.InitialMessage();
            _IConsoleClient.OutputMessageBlank("Welcome to library system.");
            _IConsoleClient.OutputMessageBlank("Please enter   your choice: ");
            _IConsoleClient.OutputMessageBlank("To entry student information enter: 1");
            _IConsoleClient.OutputMessageBlank("To entry book information enter: 2");
            _IConsoleClient.OutputMessageBlank("To issue a book, enter:   3");
            _IConsoleClient.OutputMessageBlank("To   return a book enter: 4");
            _IConsoleClient.OutputMessageBlank("To check fine, enter: 5");
            _IConsoleClient.OutputMessageBlank("To receive fine,   enter: 6");

            _IConsoleClient.OutputMessageBlank("");
            _IConsoleClient.OutputMessageBlank("");
            _IConsoleClient.OutputMessage("Enter");
            int choicekey = Int32.Parse(_IConsoleClient.ClientInput());
            _IConsoleClient.InitialMessage();
            return choicekey;
        }
    }
}
