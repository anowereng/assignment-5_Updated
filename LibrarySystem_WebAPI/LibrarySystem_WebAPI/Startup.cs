using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem_WebAPI_Store;
using LibrarySystem_WebAPI_Store.Interfaces;
using LibrarySystem_WebAPI_Store.IRepository;
using LibrarySystem_WebAPI_Store.IServices;
using LibrarySystem_WebAPI_Store.Repository;
using LibrarySystem_WebAPI_Store.Services;
using LibrarySystem_WebAPI_Store.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LibrarySystem_WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;
            var connstring = Configuration.GetConnectionString("DefaultConnection");

            services.
                     /*For Defendency another assembly */
                         AddTransient<LibrarySystemContext>(x => new LibrarySystemContext(connstring, migrationAssemblyName)).
                         AddTransient<LibraryUnitOfWork>(x => new LibraryUnitOfWork(connstring, migrationAssemblyName));
            /* For migraion */
            services.AddDbContext<LibrarySystemContext>(x => x.UseSqlServer(connstring, m => m.MigrationsAssembly(migrationAssemblyName)));
                    /*For Repository and services*/
            services.
                     AddTransient<IBookRepository, BookRepository>().
                     AddTransient<IBookService, BookService>().
                     AddTransient<IStudentRepository, StudentRepository>().
                     AddTransient<IStudentService, StudentService>().
                     AddTransient<IBookIssueRepository, BookIssueRepository>().
                     AddTransient<IBookIssueService, BookIssueService>().
                     AddTransient<IBookReturnRepository, BookReturnRepository>().
                     AddTransient<IBookReturnService, BookReturnService>().
                     AddTransient<IBookFineRepository, BookFineRepository>().
                     AddTransient<IBookFineService, BookFineService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
