using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Notes.Application;
using Notes.Persistence;
using NotesApplication.common.mapping;
using NotesApplication.Interfaces;
using NotesPersistence;
using NotesWebApi.Middleware;
using static System.Formats.Asn1.AsnWriter;

namespace NotesWebApi
{
    public class Program
    {
       public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddApplication();
            builder.Services.AddControllers();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddAutoMapper(config =>
            {
                
                config.AddProfile(new AssemblyMapperProfile(typeof(Program).Assembly));
                config.AddProfile(new AssemblyMapperProfile(typeof(INoteDbContext).Assembly));
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            builder.Services.AddSwaggerGen();

            builder.Services.AddEndpointsApiExplorer();
            var app = builder.Build();
            app.UseMiddleware<MiddlewareExceptionHandler>();
            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<NoteDbContext>();
                    DbInitializer.Init(context);
                }

                catch (Exception)

                {
                    throw new Exception("That's why your are not employeed!");
                }

            }
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.RoutePrefix = string.Empty;
                    options.SwaggerEndpoint("swagger/v1/swagger.json", "Notes API");
                });
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors("AllowAll");
            app.MapControllers();
            app.Run();


        }

    }
}
