using LabWork.Data;
using LabWork.Data.Interfaces;
using LabWork.Data.Mocks;
using LabWork.Data.Models;
using LabWork.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LabWork
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IConfiguration configuration, IHostEnvironment hostEnv)
        {
            Configuration = configuration;
            //отримання файлу зі строкою підключення БД
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGames, GameRepository>();
            services.AddTransient<IDigitalCopy, DigitalCopyRepository>();
            services.AddTransient<IDeveloper, DeveloperRepository>();
            services.AddTransient<IDeveloper_has_game, Developer_has_gameRepository>();
            services.AddTransient<IPublisher, PublisherRepository>();
            services.AddTransient<IPublisher_has_game, Publisher_has_gameRepository>();
            services.AddTransient<IGenre, GenreRepository>();
            services.AddTransient<IGame_has_genre, Game_has_genreRepository>();
            services.AddTransient<IGameKey, GameKeyRepository>();
            services.AddTransient<IUserOrder, UserOrderRepository>();
            services.AddTransient<IUsers, UserRepository>();
            services.AddTransient<IOrderBasket, OrderBasketRepository>();
            services.AddMvc(mvcOptions => {
                mvcOptions.EnableEndpointRouting = false;
            });
            services.AddControllersWithViews();
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDBContent>().AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            else
            {
                app.UseExceptionHandler("/Home/Error");
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
