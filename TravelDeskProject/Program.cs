
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TravelDeskProject.IRepo;
using TravelDeskProject.Models;
using TravelDeskProject.Repo;

namespace TravelDeskProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                  {
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuer = true,
                          ValidateAudience = true,
                          ValidateLifetime = true,
                          ValidateIssuerSigningKey = true,
                          ValidIssuer = builder.Configuration["Jwt:Issuer"],
                          ValidAudience = builder.Configuration["Jwt:Audience"],
                          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                      };
                  });
            // Add services to the container.
            builder.Services.AddMemoryCache();
            builder.Services.AddControllers();
            builder.Services.AddCors(x => x.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IUserRepo, UserRepo>();
            builder.Services.AddTransient<ILoginRepo, LoginRepo>();
            builder.Services.AddDbContext<TravelDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:TravelDatabase"]));

            builder.Services.AddScoped<DbInitializer>();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseItToSeedSqlServer();
            app.UseHttpsRedirection();



            app.UseCors("AllowOrigin");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
