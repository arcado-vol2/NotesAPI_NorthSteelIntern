using MediatR;

namespace NotesApplication.Notes.Queries
{
    public class GetNoteBodyQuery : IRequest<NoteBodyViewModel>
    {
        public Guid userID { get; set; }
        public Guid ID { get; set; }
    }
}
