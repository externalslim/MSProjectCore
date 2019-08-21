using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MS.Application.DependencyResolver;
using MS.Helper.Mapping;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;

namespace MS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            /*JWT Authentication*/
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Issuer"],
                        ValidAudience = Configuration["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SigningKey"]))
                    };
                });
            /*JWT Authentication*/

            services.AddMvc();

            /*Automapper*/
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            var mapper = autoMapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            /*Automapper*/

            /*SwaggerGen*/
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CoreSwagger", new Info
                {
                    Title = "Swagger on ASP.NET Core",
                    Version = "1.0.0",
                    Description = "Try Swagger on (ASP.NET Core 2.2)",
                    Contact = new Contact()
                    {
                        Name = "Swagger Implementation",
                        Url = "",
                        Email = "cihanagirbas@gmail.com"
                    },
                    TermsOfService = "http://swagger.io/terms/"
                });
            });
            /*SwaggerGen*/

            /*IOC Resolver*/
            var container = new ServiceResolver(services).GetServiceProvider();
            /*IOC Resolver*/

            /*CORS*/
            services.AddCors();
            /*CORS*/

            return container;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*CORS Settings*/
            app.UseCors(builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
            /*CORS Settings*/

            /*Swagger Options*/
            app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "MSServer .Net Core");
            });
            /*Swagger Options*/

            /*Set Authentication*/
            app.UseAuthentication();
            /*Set Authentication*/


            app.UseMvc();
        }
    }
}
