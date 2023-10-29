using MediatR;

namespace NotesApplication.Notes.Commands
{
    public class UpdateNoteCommand : IRequest<Guid>
    {
        public Guid userID { get; set; }
        public Guid ID { get; set; }
        public string head { get; set; }
        public string body { get; set; }
    }
}
