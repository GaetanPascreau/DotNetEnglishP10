
using DoctorNotesService.Models;
using DoctorNotesService.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DoctorNotesService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<NoteStoreDatabaseSettings>(
                builder.Configuration.GetSection(nameof(NoteStoreDatabaseSettings)));

            builder.Services.AddSingleton<INoteStoreDatabaseSettings>( sp =>
            sp.GetRequiredService<IOptions<NoteStoreDatabaseSettings>>().Value);

            builder.Services.AddSingleton<IMongoClient>(s =>
            new MongoClient(builder.Configuration.GetValue<string>("NoteStoreDatabaseSettings:ConnectionString")));

            builder.Services.AddScoped<INoteService, NoteService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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