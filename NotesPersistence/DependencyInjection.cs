using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NotesPersistence;
using NotesApplication.Interfaces;

namespace Notes.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<NoteDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<INoteDbContext>(provider =>
                provider.GetService<NoteDbContext>());
            return services;
        }
    }
}