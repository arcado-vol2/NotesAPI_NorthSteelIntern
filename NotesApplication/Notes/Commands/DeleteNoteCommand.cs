using MediatR;
using System;

namespace NotesApplication.Notes.Commands
{
    public class DeleteNoteCommand : IRequest<Unit>
    {
        public Guid userID { get; set; }
        public Guid ID { get; set; }
    }
}
