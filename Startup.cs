using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;




namespace aspnetcoreapp
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase()
                );

            services.AddSingleton<Interfaces.IPersonRepository, Repositories.PersonRepository>();

            services.AddSignalR();

            // https://www.myget.org/feed/aspnetcidev/package/nuget/Microsoft.AspNetCore.SignalR.Server
            services.AddSingleton<Interfaces.ICommentRepository, Repositories.CommentRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddConsole();
    loggerFactory.AddDebug();
        

    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        /*app.UseDatabaseErrorPage();
        app.UseBrowserLink();*/
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
    }

    app.UseStaticFiles();

    // app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            
            /*
            app.Run(context =>
            {
                return context.Response.WriteAsync("Hello from ASP.NET Core!");
            });
            */
        }
    }
}