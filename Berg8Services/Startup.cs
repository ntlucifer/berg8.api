using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace api
{

    public struct Setting
    {
        public const string policyOriginName = "AllowBerg8WebAccessOrigin";
        public const string strOriginApiDomain = @"http://localhost:3000";
        public const string strOriginApiDomainSameOrigin = @"https://0.0.0.0:80";
    }
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
            services.AddMvc();
            services.AddCors(
                options => options.AddPolicy(Setting.policyOriginName,
                            builder => {
                                        builder
                                                .AllowAnyOrigin()
                                               //.WithOrigins(Setting.strOriginApiDomain)
                                               .AllowCredentials()
                                               .AllowAnyMethod()
                                               //.WithHeaders("accept", "content-type", "origin", "x-custom-header")
                                               .AllowAnyHeader()
                                        ;}
                            )
            ); //Add Corss Origin Resource Sharing


            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(Setting.policyOriginName));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();

        }
    }
}
