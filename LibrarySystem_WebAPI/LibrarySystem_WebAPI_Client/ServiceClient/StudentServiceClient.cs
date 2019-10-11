using LibrarySystem_WebAPI_Client.IModelGateway;
using LibrarySystem_WebAPI_Client.IServiceClient;
using LibrarySystem_WebAPI_Client.ModelGateway;
using System;
using System.Collections.Generic;
using System.Text;
using LibrarySystem_WebAPI_Client.IRestApiServices;

namespace LibrarySystem_WebAPI_Client.ServiceClient
{
    public class StudentServiceClient : IStudentServiceClient
    {
        private IStudentGateway _studentGateway;
        private IRestApiService _restApiService;
        private static string _apiController;
        public StudentServiceClient(IStudentGateway studentGateway, IRestApiService restApiService)
        {
            _studentGateway = studentGateway;
            _restApiService = restApiService; _apiController = "Student";
        }
        public void StudentPost()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                var data = _studentGateway.InputStudentData();

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
