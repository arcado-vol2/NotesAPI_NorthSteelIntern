
namespace NotesPersistence
{
    public class DbInitializer
    {
        public static void Init(NoteDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
