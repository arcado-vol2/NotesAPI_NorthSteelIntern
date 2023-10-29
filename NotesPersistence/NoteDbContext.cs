using Microsoft.EntityFrameworkCore;
using NotesBase;
using NotesApplication.Interfaces;
using NotesPersistence.Configurations;

namespace NotesPersistence
{
    public class NoteDbContext : DbContext, INoteDbContext
    {
        public DbSet<Note> notes { get; set; }
        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options) 
        { 
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
