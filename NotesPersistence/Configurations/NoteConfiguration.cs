using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotesBase;

namespace NotesPersistence.Configurations
{
    internal class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(note => note.ID);
            builder.HasIndex(note => note.ID).IsUnique();
            builder.Property(note => note.head).HasMaxLength(128);
        }
    }
}
