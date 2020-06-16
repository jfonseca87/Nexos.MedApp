using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Nexos.MedApp.Repository.Interfaces;
using Nexos.MedApp.Repository.SQLImplementation;
using Nexos.MedApp.Service.Interfaces;
using Nexos.MedApp.Service.ServiceImplementations;

namespace Nexos.MedApp.API
{
    public class Startup
    {
        private readonly IConfiguration conf;
        private readonly string corsPolicy = "MedCors";

        public Startup(IConfiguration _conf)
        {
            conf = _conf;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Med API v1", Version = "v1" });
            });

            services.AddCors(config =>
            {
                config.AddPolicy(corsPolicy,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.AddDbContext<MedContext>(options => options.UseSqlServer(conf["ConnectionStrings:MedConnection"]));

            // Repository DI Containers
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IPatientDoctorsRepository, PatientDoctorsRepository>();

            // Services DI Containers
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IPatientDoctorsService, PatientDoctorsService>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(corsPolicy);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Med API v1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
