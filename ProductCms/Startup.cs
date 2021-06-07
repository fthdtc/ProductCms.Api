using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using ProductCms.Attribute;
using ProductCms.Data.Context;
using ProductCms.Service.Middleware;

namespace ProductCms
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(opts => {
                opts.Filters.Add(new ActionLogAttribute());
            });

            services.Configure<ConnectionStringSettings>(Configuration.GetSection("ConnectionStrings"));

            var connectionString = Configuration["ConnectionStrings:ProductCmsConnection"];
            var builder = new NpgsqlConnectionStringBuilder(connectionString) { };
            services.AddDbContext<EFCoreContext>(options => options.UseNpgsql(builder.ConnectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<LoggerMiddleware>();
            app.UseMvc();
        }
    }
}
