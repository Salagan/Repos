using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;
using ZRdemoData.Repositories;
using ZRdemoData.UnitOfWork;

namespace ZRdemo3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IMapper Config { get; set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ZRdemoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ZRdemo3ConnStr"),
                b => b.MigrationsAssembly(typeof(ZRdemoContext).Assembly.FullName)));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZRdemo3", Version = "v1" });
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICoachRepository, CoachRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IGymRepository, GymRepository>();
            services.AddTransient<IGroupOfStudentsRepository, GroupOfStudentsRepository>();
            services.AddTransient<ITrainingRepository, TrainingRepository>();
            services.AddTransient<ITrainingDayRepository, TrainingDayRepository>();
            services.AddTransient<IGuestCoachRepository, GuestCoachRepository>();
            services.AddTransient<IGuestRepository, GuestRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZRdemo3 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
