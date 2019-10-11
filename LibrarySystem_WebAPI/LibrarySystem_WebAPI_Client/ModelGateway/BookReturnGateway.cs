using LibrarySystem_WebAPI_Client.IModelConsole;
using LibrarySystem_WebAPI_Client.IModelGateway;
using LibrarySystem_WebAPI_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Library_Management_System.ModelGateway
{
    class BookReturnGateway : IBookReturnGateway
    {
        private IConsoleClient _ConsoleClient;
        public BookReturnGateway(IConsoleClient ConsoleClient)
        {
            _ConsoleClient = ConsoleClient;
        }
      
        public ReturnBook InputReturnBookData()
        {
            ReturnBook model = new ReturnBook();

            /*  Student Id  */
            _ConsoleClient.InitialMessage();
            _ConsoleClient.OutputMessage("StudentId");
            model.StudentId = Int32.Parse(_ConsoleClient.ClientInput());

            /*  BarCode   */
            _ConsoleClient.InitialMessage();
            _ConsoleClient.OutputMessage("Barcode");
            model.Barcode = _ConsoleClient.ClientInput();

            return model;
          
        }
    }
}
