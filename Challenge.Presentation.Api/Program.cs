using Microsoft.EntityFrameworkCore;
using Challenge.Infra.Data.Context;
using Challenge.Presentation.Api.Extensions;
using StackExchange.Redis;
using Challenge.ApplicationService.Services.Contracts;

namespace Challenge.Presentation.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.ConfigureDependencyInjection();
            builder.Services.AddDbContext<ChallengeContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("CacheConnection") ?? throw new Exception("CacheConnection is null")));

            var app = builder.Build();

            //Removido para o desafio
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            //Removido para o desafio
            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}