using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Rewrite;

using Frap3Core.BCore;

using Dsms.Business;

namespace Dsms
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{

        //    Configuration = configuration;
        //}
        public Startup(IHostingEnvironment env)
        {

            //�\���t�@�C���A���ϐ�������A�\���������[�h
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            //�\�������v���p�e�B�ɐݒ�
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuration���V���O���g����
            services.AddSingleton<IConfiguration>(Configuration);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // ASP.NET Core MVC��Session�Ǘ�
            // In-Memory
            services.AddDistributedMemoryCache();
            //services.AddSession();
            services.AddSession(options =>
            {
                //options.Cookie.HttpOnly = true;
                //options.Cookie.Name = ".Fiver.Session";
                //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.IdleTimeout = TimeSpan.FromMinutes(1);
            });

            services.AddMvc().AddRazorOptions(options =>
            {
                // {0} - Action Name
                // {1} - Controller Name
                // {2} - Area Name
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}.cshtml");
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //�\����񂩂�AUserSettings �N���X�փo�C���h
            services.Configure<Frap3Core.BCore.ConnectionInfo>(this.Configuration.GetSection("Connectioninfo"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // ASP.NET Core MVC��Session�Ǘ�
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{area}/{controller}/{action}",
                    defaults: new { area = "DME001", controller = "DME001_001", action = "Init" });
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area=DME001}/{controller=DME001_001}/{action=Init}/{id?}");
            });
        }
    }
}
