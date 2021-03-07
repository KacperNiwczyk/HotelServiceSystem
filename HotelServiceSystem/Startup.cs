using HotelServiceSystem.Core;
using HotelServiceSystem.Core.BackgroundWorkers;
using HotelServiceSystem.Core.Helpers;
using HotelServiceSystem.Core.Repositories;
using HotelServiceSystem.Core.Service;
using HotelServiceSystem.Interfaces.Helpers;
using HotelServiceSystem.Interfaces.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using HotelServiceSystem.Interfaces.Services;
using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

namespace HotelServiceSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMatBlazor();
            
            //MudBlazor
            services.AddMudBlazorDialog();
            services.AddMudBlazorSnackbar();
            services.AddMudBlazorResizeListener();
            services.AddMudBlazorScrollListener();
            services.AddMudBlazorScrollManager();
            services.AddMudBlazorDom();
            
            services.AddScoped<AuthenticationStateProvider, HotelServiceAuthenticationStateProvider>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IRoomHelper, RoomHelper>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClientService, ClientService>();
            
            services.AddTransient<IHotelReservationRepository, HotelReservationRepository>();
            services.AddTransient<IHotelReservationService, HotelReservationService>();
            
            services.AddTransient<IEventReservationRepository, EventReservationRepository>();
            services.AddTransient<IEventReservationService, EventReservationService>();
            
            services.AddTransient<IAdditionalServiceRepository, AdditionalServiceRepository>();
            services.AddTransient<IAdditionalServiceService, AdditionalServiceService>();
            services.AddTransient<IAdditionalServiceHelper, AdditionalServiceHelper>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IUpdateStatusWorker, UpdateStatusWorker>();
            services.AddHostedService<UpdateStatusBackgroundService>();
            
            services.AddDbContext<HotelServiceDatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                if (serviceScope != null)
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<HotelServiceDatabaseContext>();
                    context.Database.Migrate();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}