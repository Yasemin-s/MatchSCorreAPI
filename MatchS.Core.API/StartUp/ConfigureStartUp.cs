using MatchS.Core.API.AutoMapperProfile;
using MatchS.Core.Common.City;
using MatchS.Core.Data;
using MatchS.Core.Data.Datas;
using MatchS.Core.Data.Initialize;
using MatchS.Core.Data.Interfaces;
using MatchS.Core.Service.Interfaces;
using MatchS.Core.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace MatchS.Core.API.StartUp
{
    public static class ConfigureStartUp
    {
        public static void ServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(x =>
            {
                x.AddPolicy("AllowOrigins", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddTransient<DatabaseInitializer>();
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("MatchSql"));
            });
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.LoginPath = "/api/User/login";
                opt.LoginPath = "/api/User/logout";
                opt.ExpireTimeSpan = TimeSpan.FromHours(1);
            });
            services.AddAuthorization();

            services.AddScoped<IAdvertDatas, AdvertDatas>();
            services.AddScoped<IAdvertService, AdvertService>();

            services.AddScoped<ICommentDatas, CommentDatas>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddScoped<IMessageDatas, MessageDatas>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddScoped<IParticipantDatas, ParticipantDatas>();
            services.AddScoped<IParticipantService, ParticipantService>();

            services.AddScoped<IUserDatas, UserDatas>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ICategoryDatas, CategoryDatas>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ICityCommon, CityCommon>();

        }

        public static WebApplication AppConfiguration(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var initializer = services.GetRequiredService<DatabaseInitializer>();
                initializer.InitializeDatabase().Wait();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowOrigins");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

            return app;
        }
    }
}