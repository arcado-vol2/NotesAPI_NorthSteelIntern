using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Interfaces;

namespace NotesApplication.Notes.Commands
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Guid>
    {
        private readonly INoteDbContext _dbContext;
        public UpdateNoteCommandHandler(INoteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.notes.FirstOrDefaultAsync(note => note.ID == request.ID, cancellationToken);
            if (entity == null || entity.userID != request.userID) 
            {
                throw new Exception($"Note {request.ID} not found");
            }
            entity.head = request.head;
            entity.body = request.body;
            entity.updatedDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.ID;
        }
    }
}
