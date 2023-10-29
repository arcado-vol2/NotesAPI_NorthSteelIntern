using MediatR;

namespace NotesApplication.Notes.Commands
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public Guid userID { get; set; }
        public string head {  get; set; }
        public string body { get; set; }
    }
}
