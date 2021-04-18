using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using Salon.CustomerBase.Infrastructure.Data;
using Salon.CustomerBase.Infrastructure.Repositories.Implementations;
using Salon.CustomerBase.Infrastructure.Repositories.Interfaces;
using Salon.Eventbus.RabbitMQ;
using Salon.Eventbus.RabbitMQ.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.CustomerBase.API
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
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            //   services.AddAutoMapper(typeof(Startup));

            #endregion

            #region Swagger Dependencies

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Customer service",
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





            // services.AddScoped<IDataAccessProvider, DataAccessProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();

          

           

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Initilize Rabbit Listener in ApplicationBuilderExtentions
          ///  app.UseRabbitListener();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Service");
            });
        }
    }
}
