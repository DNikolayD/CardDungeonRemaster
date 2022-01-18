using Autofac.Core;
using AutoMapper;
using Data;
using Data.Entities;
using Data.Entities.Common;
using Data.Entities.Forum;
using Data.Entities.User;
using Data.Repositories.Base;
using Data.Repositories.Classes;
using Data.Repositories.Classes.Cards;
using Data.Repositories.Classes.Posts;
using Data.Repositories.Classes.User;
using Data.Repositories.Intrefaces;
using Data.Repositories.Intrefaces.Cards;
using Data.Repositories.Intrefaces.Posts;
using Data.Repositories.Intrefaces.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Service.Classes;
using Service.Classes.Cards;
using Service.Common;
using Service.DTOs;
using Service.DTOs.Posts;
using Service.DTOs.User;
using Service.Interfaces.Cards;
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

            services.AddControllersWithViews().AddNewtonsoftJson( options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                ).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()); // in case of using JSON Request/Response to work with the DB
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
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IRolesRepository, RolesRepository>();

            services.AddTransient<ICardsService, CardsService>();
            services.AddTransient<ICardTypesService, CardTypesService>();
            services.AddTransient<IEffectsService, EffectsService>();
            services.AddTransient<IEffectTypesService, EffectTypesService>();
            services.AddTransient<IDecksService, DecksService>();
            services.AddTransient<IDeckTypesService, DeckTypesService>();



            var configuration = new MapperConfiguration(x =>
                {
                    x.AllowNullCollections = true;
                    x.CreateMap<CardsDataEntity, CardsDto>();
                    x.CreateMap<CardsDto, CardsDataEntity>();
                    x.CreateMap<CardTypesDataEntity, CardTypesDto>();
                    x.CreateMap<CardTypesDto, CardTypesDataEntity>();
                    x.CreateMap<DecksDataEntity, DecksDto>();
                    x.CreateMap<DecksDto, DecksDataEntity>();
                    x.CreateMap<DeckTypesDataEntity, DeckTypesDto>();
                    x.CreateMap<DeckTypesDto, DeckTypesDataEntity>();
                    x.CreateMap<EffectsDataEntity, EffectsDto>();
                    x.CreateMap<EffectsDto, EffectsDataEntity>();
                    x.CreateMap<EffectTypesDataEntity, EffectTypesDto>();
                    x.CreateMap<EffectTypesDto, EffectTypesDataEntity>();
                    x.CreateMap<ImagesDataEntity, ImagesDto>();
                    x.CreateMap<ImagesDto, ImagesDataEntity>();
                    x.CreateMap<CategoriesDataEntity, CategoriesDto>();
                    x.CreateMap<CategoriesDto, CategoriesDataEntity>();
                    x.CreateMap<PostsDataEntity, PostsDto>();
                    x.CreateMap<PostsDto, PostsDataEntity>();
                    x.CreateMap<CommentsDataEntity, CommentsDto>();
                    x.CreateMap<CategoriesDto, CommentsDataEntity>();
                    x.CreateMap<ApplicationUser, UserDto>();
                    x.CreateMap<UserDto, ApplicationUser>();
                    x.CreateMap<ApplicationRole, RoleDto>();
                    x.CreateMap<RoleDto, ApplicationRole>();
                }
           );

            configuration.AssertConfigurationIsValid();

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
