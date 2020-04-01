using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockTrading.Receiver.Methods;
using StockTrading.Receiver.Repository;
using StockTrading.Receiver.Services;

namespace StockTrading.Receiver {
    public class Startup {

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
<<<<<<< HEAD
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddAWSService<IAmazonDynamoDB>();

            services.AddSingleton<IStockService, StockService>();
            services.AddSingleton<IStockRepository, StockRepository>();
            services.AddSingleton<IMapper, Mapper>();
=======
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllers();
>>>>>>> master
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
