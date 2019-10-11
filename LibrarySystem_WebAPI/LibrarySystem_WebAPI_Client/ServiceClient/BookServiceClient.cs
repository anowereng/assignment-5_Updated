using LibrarySystem_WebAPI_Client.IModelGateway;
using LibrarySystem_WebAPI_Client.IRestApiServices;
using LibrarySystem_WebAPI_Client.ModelGateway;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem_WebAPI_Client.ServiceClient
{
    public class BookServiceClient: IBookServiceClient
    {
        private IBookGateway _bookGateway;
        private IRestApiService _restApiService;
        private static string _apiController;
        public BookServiceClient(IBookGateway bookGateway, IRestApiService restApiGateway)
        {
            _bookGateway = bookGateway;
            _restApiService = restApiGateway; _apiController = "Book";
        }
        public void BookPost()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                var data = _bookGateway.InputBookData();

                if (data != null)
                    _restApiService.POST(data, _apiController);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\u263A" + "ERROR : " + ex.Message);
            }
        }
    }
}
