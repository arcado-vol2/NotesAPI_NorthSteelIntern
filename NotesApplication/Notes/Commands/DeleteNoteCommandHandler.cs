using MediatR;
using NotesApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Commands
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private readonly INoteDbContext _dbContext;
        public DeleteNoteCommandHandler(INoteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.notes.FindAsync(new object[] { request.ID }, cancellationToken);
            if (entity == null || entity.userID != request.userID)
            {
                throw new Exception($"Note {request.ID} not found");
            }
            _dbContext.notes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
