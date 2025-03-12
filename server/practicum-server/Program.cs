
using Microsoft.Extensions.DependencyInjection;
using Practicum.Core.IRepositories;
using Practicum.Data;
using Practicum.Data.Repositories;
using Practicum.Service.Services;
using Amazon;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

namespace practicum_server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //aws
            try
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
                    .Build();

                // הדפסת כל הערכים מהקונפיגורציה
                Console.WriteLine("AccessKey: " + configuration["AWS:AccessKey"]);
                Console.WriteLine("SecretKey: " + configuration["AWS:SecretKey"]);
                Console.WriteLine("Region: " + configuration["AWS:Region"]);
                Console.WriteLine("BucketName: " + configuration["AWS:BucketName"]);

                var s3Client = new AmazonS3Client(
                    configuration["AWS:AccessKey"],
                    configuration["AWS:SecretKey"],
                    RegionEndpoint.GetBySystemName(configuration["AWS:Region"]));

                var bucketName = configuration["AWS:BucketName"];
                Console.WriteLine($"Connected to S3 bucket: {bucketName} successfully!");
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }


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
            builder.Services.AddScoped<ReMarkService>();
            //repositories
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IProgramFileRepository, ProgramFileRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IReMarkRepository, ReMarkRepository>();
            //data
            builder.Services.AddDbContext<DataContext>();
            var app = builder.Build();
            //cycle
            builder.Services.AddControllers();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

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
