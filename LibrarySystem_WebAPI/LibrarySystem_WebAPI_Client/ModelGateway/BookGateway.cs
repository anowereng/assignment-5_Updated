using LibrarySystem_WebAPI_Client.IInputOutputClient;
using LibrarySystem_WebAPI_Client.IModelConsole;
using LibrarySystem_WebAPI_Client.IModelGateway;
using LibrarySystem_WebAPI_Client.ModelConsole;
using LibrarySystem_WebAPI_Entity.IModels;
using LibrarySystem_WebAPI_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace LibrarySystem_WebAPI_Client.ModelGateway
{
   public class BookGateway : IBookGateway
    {
        private IConsoleClient _IConsoleClient;

        private IBook _bookModel;
        public IBook bookModel
        {
            set
            {
                this._bookModel = value;
            }
            get
            {
                if (_bookModel == null)
                {
                    throw new Exception("Book is not initialized");
                }
                else
                {
                    return _bookModel;
                }
            }
        }

        public BookGateway(IConsoleClient IConsoleClient)
        {
            _IConsoleClient = IConsoleClient; 
        }

        public Book InputBookData()
        {
            Book bookModel = new Book();
            /* Book title */
            _IConsoleClient.InitialMessage();
            _IConsoleClient.OutputMessage("title");
            bookModel.Title = _IConsoleClient.ClientInput();

            /* Book edition */

            _IConsoleClient.InitialMessage();
            _IConsoleClient.OutputMessage("edition");
            bookModel.Edition = _IConsoleClient.ClientInput();

            /* Book author */

            _IConsoleClient.InitialMessage();
            _IConsoleClient.OutputMessage("author");
            bookModel.Author = _IConsoleClient.ClientInput();

            /* Book barcode */
            _IConsoleClient.InitialMessage();
            _IConsoleClient.OutputMessage("barcode");
            bookModel.Barcode = _IConsoleClient.ClientInput();

            /* Book copy  */
            _IConsoleClient.InitialMessage();
            _IConsoleClient.OutputMessage("book copy");
            bookModel.Copycount = Int32.Parse(_IConsoleClient.ClientInput());

            return bookModel;
        }
    }
}
