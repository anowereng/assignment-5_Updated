using LibrarySystem_WebAPI_Client.IModelConsole;
using LibrarySystem_WebAPI_Client.IModelGateway;
using LibrarySystem_WebAPI_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LibrarySystem_WebAPI_Client.ModelGateway
{
    class StudentGateway : IStudentGateway
    {
        private IConsoleClient _IConsoleClient;

        public StudentGateway(IConsoleClient IConsoleClient)
        {
            _IConsoleClient = IConsoleClient;
        }

        public Student InputStudentData()
        {
            Student bookModel = new Student();

            /* student Name */
            _IConsoleClient.InitialMessage();
            _IConsoleClient.OutputMessage("Name");

            bookModel.Name = _IConsoleClient.ClientInput();

            return bookModel;
        }

    }
}
