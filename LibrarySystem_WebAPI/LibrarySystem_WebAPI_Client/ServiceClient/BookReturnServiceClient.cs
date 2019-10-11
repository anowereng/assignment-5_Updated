using LibrarySystem_WebAPI_Client.IModelGateway;
using LibrarySystem_WebAPI_Client.IRestApiServices;
using LibrarySystem_WebAPI_Client.IServiceClient;
using System;

namespace LibrarySystem_WebAPI_Client.ServiceClient
{
    public class BookReturnServiceClient : IBookReturnServiceClient
    {
        private IBookReturnGateway _bookReturnGateway;
        private IRestApiService _restApiService;
        private static string _apiController;
        public BookReturnServiceClient(IBookReturnGateway bookReturnGateway, IRestApiService restApiGateway)
        {
            _bookReturnGateway = bookReturnGateway;
            _restApiService = restApiGateway; _apiController = "BookReturn";
        }
        public void PostBookReturn()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                var data = _bookReturnGateway.InputReturnBookData();

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
