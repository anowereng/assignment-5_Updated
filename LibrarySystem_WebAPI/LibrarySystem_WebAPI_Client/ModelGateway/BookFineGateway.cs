using LibrarySystem_WebAPI_Client.IModelConsole;
using LibrarySystem_WebAPI_Client.IModelGateway;
using LibrarySystem_WebAPI_Entity.Models;
using System;
using System.Linq;
namespace Library_Management_System.ModelGateway
{
    public class BookFineGateway : IBookFineGateway
    {
        private IConsoleClient _IConsoleClient;
        public BookFineGateway(IConsoleClient ConsoleClient)
        {
            _IConsoleClient = ConsoleClient;
        }

        public Student InputForCheckFine()
        {
            Student model = new Student();

            /* Student Id */
            _IConsoleClient.InitialMessage();
            _IConsoleClient.OutputMessage("Student Id");
            model.Id = Int32.Parse(_IConsoleClient.ClientInput());

            return model;
        }

        public Student InputForReceiveFine()
        {
            Student model = new Student();

            /* Studnet Id */
            _IConsoleClient.InitialMessage();
            _IConsoleClient.OutputMessage("Student Id");
            model.Id = Int32.Parse(_IConsoleClient.ClientInput());

            /* Fine Amount */
            _IConsoleClient.InitialMessage();
            _IConsoleClient.OutputMessage("Amount");
            model.FineAmount = Int32.Parse(_IConsoleClient.ClientInput());

            return model;
        }
    }
}
