using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IC6.TutorialCQRS.Commands;
using IC6.TutorialCQRS.Model;
using IC6.TutorialCQRS.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IC6.TutorialCQRS
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


            services.AddScoped<IQueriesService, QueriesService>(ctor => new QueriesService(Configuration["ConnectionString"]));
            services.AddScoped<ICommandService, CommandService>();

            services.AddDbContext<BlogContext>(optionsAction: optionsBuilder =>
                optionsBuilder.UseSqlServer(Configuration["ConnectionString"],
                optionsAction => optionsAction.MigrationsAssembly(typeof(BlogContext).GetTypeInfo().Assembly.GetName().Name)));



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<BlogContext>();
                context.Database.Migrate();
            }


            app.UseMvc();
        }
    }
}
