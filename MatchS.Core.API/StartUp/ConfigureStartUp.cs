using MatchS.Core.API.AutoMapperProfile;
using MatchS.Core.Common.City;
using MatchS.Core.Data;
using MatchS.Core.Data.Datas;
using MatchS.Core.Data.Initialize;
using MatchS.Core.Data.Interfaces;
using MatchS.Core.Service.Interfaces;
using MatchS.Core.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Salla"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "yasemin",
                        ValidAudience = "yaso",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yasemininsifresi24karakterliolsun"))
                    };
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