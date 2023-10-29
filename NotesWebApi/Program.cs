using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Notes.Application;
using Notes.Persistence;
using NotesApplication.common.mapping;
using NotesApplication.Interfaces;
using NotesPersistence;
using static System.Formats.Asn1.AsnWriter;

namespace NotesWebApi
{
    public class Program
    {
       /* public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            builder.Services.AddControllers();
            builder.Services.AddDbContext<NoteDbContext>();
            
            var app = builder.Build();

            var serviceProvider = app.Services.CreateScope().ServiceProvider;

            var options = serviceProvider.GetRequiredService<DbContextOptions<NoteDbContext>>();

            var context = new NoteDbContext(options);
            DbInitializer.Init(context);


            app.UseCors("AllowAll");
            app.MapControllers();

            app.Run();

        }*/
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

            builder.Services.AddEndpointsApiExplorer();
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<NoteDbContext>();
                    DbInitializer.Init(context);
                }

                catch (Exception)

                {
                    throw new Exception("You are pidor!");
                }

            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors("AllowAll");
            app.MapControllers();
            app.Run();


        }

    }
}