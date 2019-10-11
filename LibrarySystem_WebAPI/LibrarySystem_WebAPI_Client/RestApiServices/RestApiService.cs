using LibrarySystem_WebAPI_Client.IInputOutputClient;
using LibrarySystem_WebAPI_Client.IRestApiServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace LibrarySystem_WebAPI_Client.RestApiServices
{
    public class RestApiService : IRestApiService
    {
        private IOutputClient _OutputClient;

        private static string stringUrl = "http://localhost:23694/api/";

        public RestApiService(IOutputClient OutputClient)
        {
            _OutputClient = OutputClient;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetAll()
        {
            throw new NotImplementedException();
        }

        public object GetById(int id, string apiController)
        {
            object result = "";
            var request = WebRequest.Create(stringUrl + apiController + "/"+id);
            request.Method = "GET";
                request.ContentType = "application/json";
                using (var response = request.GetResponse())
                {
                    using (var streamItem = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(streamItem))
                        {
                            result = reader.ReadToEnd();
                            Console.WriteLine(result);
                            dynamic item = JsonConvert.DeserializeObject(result.ToString());
                        }
                    }
                }
            return result;
        }

        public void POST(object model, string apiController)
        {
            try
            {
                {
                    var request = WebRequest.Create(stringUrl+ apiController);
                    request.Method = "POST";
                    request.ContentType = "application/json";

                    var requestContent = JsonConvert.SerializeObject(model);
                    var data = Encoding.UTF8.GetBytes(requestContent);
                    request.ContentLength = data.Length;

                    using (var requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(data, 0, data.Length);
                        requestStream.Flush();

                        using (var response = request.GetResponse())
                        {
                            using (var streamItem = response.GetResponseStream())
                            {
                                using (var reader = new StreamReader(streamItem))
                                {
                                    var result = reader.ReadToEnd();
                                    Console.WriteLine(result);
                                }
                            }
                        }
                    }
                }
                _OutputClient.WriteLine("Saved Successfully !!");
            }
            catch(Exception ex) { _OutputClient.WriteLine(ex.Message);};
           
        }

        public void Put(int id, object model, string apiController)
        {
            try
            {
                {
                    var request = WebRequest.Create(stringUrl + apiController + "/" +id);
                    request.Method = "PUT";
                    request.ContentType = "application/json";

                    var requestContent = JsonConvert.SerializeObject(model);
                    var data = Encoding.UTF8.GetBytes(requestContent);
                    request.ContentLength = data.Length;

                    using (var requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(data, 0, data.Length);
                        requestStream.Flush();

                        using (var response = request.GetResponse())
                        {
                            using (var streamItem = response.GetResponseStream())
                            {
                                using (var reader = new StreamReader(streamItem))
                                {
                                    var result = reader.ReadToEnd();
                                    Console.WriteLine(result);
                                }
                            }
                        }
                    }
                }
                _OutputClient.WriteLine("Updated Successfully !!");
            }
            catch (Exception ex) { _OutputClient.WriteLine(ex.Message); };
        }
    }
}
