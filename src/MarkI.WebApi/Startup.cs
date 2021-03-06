﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkI.Domain;
using MarkI.IRepository;
using MarkI.Repository;
using MarkI.Repository.Stub;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MarkI.WebApi
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
            var options = new DbContextOptionsBuilder<ApplicationContext>();
            services.AddMvc();
            services.AddTransient<IUsers, UsersRepositoryTest>();
            services.AddTransient<IDepartments,DepartmentsRepository>(s =>{
                return new DepartmentsRepository(new ApplicationContext());
            });

            services.AddTransient<IPerson,PersonRepository>(s =>{
                return new PersonRepository(new ApplicationContext());
            });
           
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
