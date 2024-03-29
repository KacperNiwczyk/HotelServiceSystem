using HotelServiceSystem.Data_access.Core;
using HotelServiceSystem.Data_access.Core.BackgroundWorkers;
using HotelServiceSystem.Data_access.Core.Repositories;
using HotelServiceSystem.Logic.Features.Helpers;
using HotelServiceSystem.Logic.Features.Service;
using HotelServiceSystem.Logic.Interfaces.Helpers;
using HotelServiceSystem.Logic.Interfaces.Repositories;
using HotelServiceSystem.Logic.Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using Newtonsoft.Json;

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
            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen();
            services.AddServerSideBlazor();

            //MudBlazor
            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 5000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            services.AddScoped<AuthenticationStateProvider, HotelServiceAuthenticationStateProvider>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddTransient<IDateManager, DateManager>();
            
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IRoomHelper, RoomHelper>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClientService, ClientService>();
            
            services.AddTransient<IHotelReservationRepository, HotelReservationRepository>();
            services.AddTransient<IHotelReservationService, HotelReservationService>();
            
            services.AddTransient<IEventReservationRepository, EventReservationRepository>();
            services.AddTransient<IEventReservationService, EventReservationService>();
            services.AddTransient<IReservationHelper, ReservationHelper>();
            
            services.AddTransient<IAdditionalServiceRepository, AdditionalServiceRepository>();
            services.AddTransient<IAdditionalServiceService, AdditionalServiceService>();

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
            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "MyHotel.io API"));
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}