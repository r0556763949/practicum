
using Microsoft.Extensions.DependencyInjection;
using Practicum.Core.IRepositories;
using Practicum.Data.Repositories;
using Practicum.Service.Services;

namespace practicum_server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Services
            builder.Services.AddScoped<ClientService>();
            builder.Services.AddScoped<ProgramFileService>();
            builder.Services.AddScoped<ProjectService>();
            builder.Services.AddScoped<RemarkService>();
            //repositories
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IProgramFileRepository, ProgramFileRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IReMarkRepository, ReMarkRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
