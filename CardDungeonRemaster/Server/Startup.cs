using Autofac.Core;
using Data;
using Data.Entities.User;
using Data.Repositories.Base;
using Data.Repositories.Classes;
using Data.Repositories.Classes.Cards;
using Data.Repositories.Classes.Posts;
using Data.Repositories.Intrefaces;
using Data.Repositories.Intrefaces.Cards;
using Data.Repositories.Intrefaces.Posts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Classes;
using Service.Interfaces;
using static Humanizer.In;

namespace CardDungeonRemaster.Server
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddIdentity<ApplicationUser, ApplicationRole>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSignalR();

            services.AddSingleton<ICardsRepository, CardsRepository>();
            services.AddSingleton<ICardTypesRepository, CardTypesRepository>();
            services.AddSingleton<IDecksRepository, DecksRepository>();
            services.AddSingleton<IDeckTypesRepository, DeckTypesRepository>();
            services.AddSingleton<IEffectsRepository, EffectsRepository>();
            services.AddSingleton<IEffectTypesRepository, EffectTypesRepository>();
            services.AddSingleton<IImagesRepository, ImagesRepository>();
            services.AddSingleton<ICategoriesRepository, CategoriesRepository>();
            services.AddSingleton<IPostsRepository, PostsRepository>();
            services.AddSingleton<ICommentsRepository, CommentsRepository>();

            services.AddTransient<ICardsService, CardsService>();
            services.AddTransient<ICardTypesService, CardTypesService>();
            services.AddTransient<IEffectsService, EffectsService>();
            services.AddTransient<IEffectTypesService, EffectTypesService>();
            services.AddTransient<IDecksService, DecksService>();
            services.AddTransient<IDeckTypesService, DeckTypesService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
