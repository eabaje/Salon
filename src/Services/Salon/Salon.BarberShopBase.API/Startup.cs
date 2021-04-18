using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Salon.BarberShopBase.Infrastructure.Data;
using Salon.BarberShopBase.Infrastructure.Repositories.Implementations;
using Salon.BarberShopBase.Infrastructure.Repositories.Interfaces;
using Salon.BarberShopBase.Infrastructure.Services.Implementations;
using Salon.BarberShopBase.Infrastructure.Settings;
using Salon.BarberShopBase.Services.Abstract;
using Salon.Eventbus.RabbitMQ;
using Salon.Eventbus.RabbitMQ.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.BarberShop.API
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
            services.AddControllers();


            services.Configure<IBarberDatabaseSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.DatabaseName = Configuration.GetSection("MongoConnection:Database").Value;
            });



            #region Connection Dependencies


            var DBConnectionString = Configuration["PostgreSqlConn"];

            services.AddDbContext<PostgresDBContext>(options => options.UseNpgsql(DBConnectionString));


            //services.AddSingleton<ConnectionMultiplexer>(sp =>
            //{
            //    var configuration = ConfigurationOptions.Parse(Configuration.GetConnectionString("Redis"), true);
            //    return ConnectionMultiplexer.Connect(configuration);
            //});

            #endregion




            #region Project Dependencies

            //services.AddTransient<IBasketContext, BasketContext>();
            //services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IBarberRepository, BarberRepository>();
            services.AddScoped<IBeautySalonRepository, BeautySalonRepository>();
            services.AddScoped<ICalendarRepository, CalendarRepository>();
            services.AddScoped<IPriceListRepository, PriceListRepository>();
            services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddScoped<IEmailService, EmailService>();
            
            //   services.AddAutoMapper(typeof(Startup));

            #endregion

            #region Swagger Dependencies

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Beauty Salon Service",
                    Version = "v1"
                });
            });

            #endregion


            #region RabbitMQ Dependencies

            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = Configuration["EventBus:HostName"]
                };

                if (!string.IsNullOrEmpty(Configuration["EventBus:UserName"]))
                {
                    factory.UserName = Configuration["EventBus:UserName"];
                }

                if (!string.IsNullOrEmpty(Configuration["EventBus:Password"]))
                {
                    factory.Password = Configuration["EventBus:Password"];
                }

                return new RabbitMQConnection(factory);
            });

            services.AddSingleton<EventBusRabbitMQProducer>();

            #endregion






        }





        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Beauty Salon Service");
            });
        }
    }
}
