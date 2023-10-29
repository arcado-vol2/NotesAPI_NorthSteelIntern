using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Interfaces;

namespace NotesApplication.Notes.Queries
{
    public class NoteBodyQueryHandler : IRequestHandler <GetNoteBodyQuery, NoteBodyViewModel>
    {
        private readonly INoteDbContext _dbContext;
        private readonly IMapper _mapper;
        public NoteBodyQueryHandler(INoteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<NoteBodyViewModel> Handle(GetNoteBodyQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.notes.FirstOrDefaultAsync(note => note.ID == request.ID, cancellationToken);
            if (entity == null || entity.userID != request.userID)
            {
                throw new Exception($"Note {request.ID} not found");
            }

            return _mapper.Map<NoteBodyViewModel>(entity);

        }
    }
}
