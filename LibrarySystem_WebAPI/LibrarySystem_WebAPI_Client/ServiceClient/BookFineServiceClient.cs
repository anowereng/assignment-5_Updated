using LibrarySystem_WebAPI_Client.IModelGateway;
using LibrarySystem_WebAPI_Client.IRestApiServices;
using LibrarySystem_WebAPI_Client.IServiceClient;
using System;

namespace LibrarySystem_WebAPI_Client.ServiceClient
{
    public class BookFineServiceClient : IBookFineServiceClient
    {
        private IBookFineGateway _bookFineGateway;
        private IRestApiService _restApiService;
        private static string _apiController;
        public BookFineServiceClient(IBookFineGateway bookFineGateway, IRestApiService restApiGateway)
        {
            _bookFineGateway = bookFineGateway;
            _restApiService = restApiGateway; _apiController = "BookFine";
        }

        public void GetFineAmount()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                var data = _bookFineGateway.InputForCheckFine();

                if (data != null)
                    _restApiService.GetById(data.Id, _apiController);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\u263A" + "ERROR : " + ex.Message);
            }
        }

        public void PostFineAmount()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                var data = _bookFineGateway.InputForReceiveFine();

                if (data != null)
                    _restApiService.Put(data.Id, data, _apiController);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\u263A" + "ERROR : " + ex.Message);
            }
        }
    }
}
