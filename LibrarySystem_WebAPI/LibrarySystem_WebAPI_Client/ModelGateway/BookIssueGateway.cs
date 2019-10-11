using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LibrarySystem_WebAPI_Client.IModelConsole;
using LibrarySystem_WebAPI_Entity.Models;
using LibrarySystem_WebAPI_Client.IModelGateway;

namespace Library_Management_System.ModelGateway
{
    class BookIssueGateway : IBookIssueGateway
    {
        private IConsoleClient _ConsoleClient;
        public BookIssueGateway(IConsoleClient ConsoleClient)
        {
            _ConsoleClient = ConsoleClient;
        }


        public IssueBook InputIssueBookData()
        {
            IssueBook model = new IssueBook();

            /*  Student Id  */
            _ConsoleClient.InitialMessage();
            _ConsoleClient.OutputMessage("StudentId");
            model.StudentId = Int32.Parse(_ConsoleClient.ClientInput());

            /*  Book Barcode  */
            _ConsoleClient.InitialMessage();
            _ConsoleClient.OutputMessage("Barcode");
            model.Barcode = _ConsoleClient.ClientInput();

            return model;
        }
    }
}
