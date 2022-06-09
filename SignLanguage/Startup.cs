using AutoMapper;
using BL;
using DL;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SignLanguage.Models;
using SignLanguage.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace SignLanguage
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
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("key").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
          
            services.AddScoped<IWordBL, WordBL>();
            services.AddScoped<IWordDL, WordDL>();
            services.AddScoped<ITestBL, TestBL>();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IUserDL, UserDL>();
            services.AddScoped<IPasswordHashHelper, PasswordHashHelper>();

            //services.AddScoped<ITextDatabaseSettings, TextDatabaseSettings>();

            //services.AddScoped<ITextBL, TextBL>();
            //services.AddScoped<ITextDL, TextDL>();

            services.AddDbContext<SignLanguageDBContext>(options => options.UseSqlServer(
               Configuration.GetConnectionString("SignLanguage")), ServiceLifetime.Scoped);
            services.AddAutoMapper(typeof(Startup));






            services.Configure<ITextDatabaseSettings>(
                Configuration.GetSection(nameof(TextDatabasesetting)));


            services.AddSingleton<TextDatabasesetting>(sp =>
                sp.GetRequiredService<IOptions<TextDatabasesetting>>().Value);

            services.AddSingleton<TextService>();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SignLanguage", Version = "v1" });

            // To Enable authorization using Swagger (JWT)    
            //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //{
            //    Name = "Authorization",
            //    Type = SecuritySchemeType.ApiKey,
            //    Scheme = "Bearer",
            //    BearerFormat = "JWT",
            //    In = ParameterLocation.Header,
            //    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
            //});
            //c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //{
            //    {
            //          new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //                }
            //            },
            //            new string[] {}

            //    }
            //});


            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SignLanguage", Version = "v1" });
                // To Enable authorization using Swagger (JWT)    
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                              new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                                new string[] {}

                        }
                    });

            });

        }
     
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseErrorMiddleware();
            app.UseCacheMiddleware();


            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SignLanguage v1"));

            }

            app.UseHttpsRedirection();
            //app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();
            //app.Map("/api", app2 =>
            //{
            //    app2.UseRouting();
            //    app2.UseRaitingMiddleware();
             
            //    app2.UseAuthorization();
            //    app2.UseEndpoints(endpoints =>
            //    {
            //        endpoints.MapControllers();
            //    });
            //} );

          
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //throw new Exception("ho no!");

            logger.LogInformation("logger-startup");
            logger.LogError("logger-mail-startup");
        }

    }
   
}
