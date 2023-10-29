using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotesBase;

namespace NotesApplication.Interfaces
{
    public interface INoteDbContext
    {
        DbSet<Note> notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
