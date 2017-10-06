using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobScheduler.Api.Infrastructure;
using JobScheduler.Api.Models;
using JobScheduler.Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Swagger;

namespace JobScheduler.Api
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
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            Func<IServiceProvider, IMongoDatabase> supplier = p => (new MongoClient("mongodb://localhost:27017")).GetDatabase("scheduling");
            services.AddTransient<IMongoDatabase>(supplier);   
            services.AddTransient<IRepositoryBase<Classification>, ClassificationRepository>();
            services.AddTransient<IRepositoryBase<JobRequest>, JobRequestRepository>();
            services.AddMvc();

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new Info { Title = "Job scheduling Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Job scheduling Api V1");
            });

            app.UseMvc();
        }
    }
}
