using LibrarySystem_WebAPI_Client.IInputOutputClient;
using LibrarySystem_WebAPI_Client.IModelGateway;
using LibrarySystem_WebAPI_Client.InputOutputClient;
using LibrarySystem_WebAPI_Client.ModelGateway;
using LibrarySystem_WebAPI_Client.ServiceClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using LibrarySystem_WebAPI_Client.IModelConsole;
using LibrarySystem_WebAPI_Client.ModelConsole;
using LibrarySystem_WebAPI_Client.IServiceClient;
using LibrarySystem_WebAPI_Client.IRestApiServices;
using LibrarySystem_WebAPI_Client.RestApiServices;
using Library_Management_System.ModelGateway;

namespace LibrarySystem_WebAPI_Client
{
    public class Program
    {

        private static IServiceProvider _serviceProvider;
        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.
                AddScoped<IDashboardService, DashboardService>().
                AddScoped<IInputClient, ConsoleInputClient>().
                AddScoped<IOutputClient, ConsoleOutputClient>().
                AddScoped<IConsoleClient, ConsoleClient>().

                AddScoped<IBookGateway, BookGateway>().
                AddScoped<IStudentGateway, StudentGateway>().

                AddScoped<IBookServiceClient, BookServiceClient>().
                AddScoped<IStudentServiceClient, StudentServiceClient>().

                AddScoped<IBookIssueGateway, BookIssueGateway>().
                AddScoped<IBookIssueServiceClient, BookIssueServiceClient>().

                AddScoped<IBookReturnGateway, BookReturnGateway>().
                AddScoped<IBookReturnServiceClient, BookReturnServiceClient>().

                AddScoped<IBookFineGateway, BookFineGateway>().
                AddScoped<IBookFineServiceClient, BookFineServiceClient>().

                AddScoped<IRestApiService, RestApiService>();

            
            _serviceProvider = collection.BuildServiceProvider();
        }
        public static void Main(string[] args)
        {
            RegisterServices();
            var dashboardService = _serviceProvider.GetService<IDashboardService>();
            int choicekey = dashboardService.InitialDashboardMessage();
            MenuSelect(choicekey);
        }
        public static void MenuSelect(int choicekey)
        {
     
            var bookService = _serviceProvider.GetService<IBookServiceClient>();
            var studentService = _serviceProvider.GetService<IStudentServiceClient>();
            var bookIssueService = _serviceProvider.GetService<IBookIssueServiceClient>();
            var bookReturnService = _serviceProvider.GetService<IBookReturnServiceClient>();
            var bookFineService = _serviceProvider.GetService<IBookFineServiceClient>();

            switch (choicekey)
            {
                case 1:
                    studentService.StudentPost();
                    break;
                case 2:
                    bookService.BookPost();
                    break;
                case 3:
                    bookIssueService.PostBookIssue();
                    break;
                case 4:
                    bookReturnService.PostBookReturn();
                    break;
                case 5:
                    bookFineService.GetFineAmount();
                    break;
                case 6:
                    bookFineService.PostFineAmount();
                    break;
                default:
                    Console.WriteLine("!!! Invalid Key ");
                    break;
            }
        }
    }
}
