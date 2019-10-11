using LibrarySystem_WebAPI_Client.IModelGateway;
using LibrarySystem_WebAPI_Client.IRestApiServices;
using LibrarySystem_WebAPI_Client.IServiceClient;
using System;

namespace LibrarySystem_WebAPI_Client.ServiceClient
{
    public class BookIssueServiceClient : IBookIssueServiceClient
    {
        private IBookIssueGateway _issueBookGateway;
        private IRestApiService _restApiService;
        private static string _apiController;
        public BookIssueServiceClient(IBookIssueGateway bookIssueGateway, IRestApiService restApiGateway)
        {
            _issueBookGateway = bookIssueGateway;
            _restApiService = restApiGateway; _apiController = "BookIssue";
        }
        public void PostBookIssue()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                var data = _issueBookGateway.InputIssueBookData();

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
