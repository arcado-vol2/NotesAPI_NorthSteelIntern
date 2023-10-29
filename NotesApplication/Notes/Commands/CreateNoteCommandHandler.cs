using System;
using System.Threading;
using System.Threading.Tasks;
using NotesBase;
using MediatR;
using NotesApplication.Interfaces;

namespace NotesApplication.Notes.Commands
{
    public class CreateNoteCommandHandler :IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INoteDbContext _dbContext;
        public CreateNoteCommandHandler(INoteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            Note note = new Note
            {
                userID = new Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8"), //just for test in real it mast be request.userID
                head = request.head,
                body = request.body,
                ID = Guid.NewGuid(),
                creationDate = DateTime.Now,
                updatedDate = null,
            };

            await _dbContext.notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return note.ID;

        }

    }
}
