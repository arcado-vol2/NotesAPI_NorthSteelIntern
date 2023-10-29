using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MediatR;
using NotesApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Queries
{
    public class GetNotesListQueryHandler : IRequestHandler<GetNotesListQuery, NoteListViewModel>
    {
        private readonly INoteDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNotesListQueryHandler(INoteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
       
        public async Task<NoteListViewModel> Handle(GetNotesListQuery request, CancellationToken cancellationToken)
        {
            var notesQuery = await (from note in _dbContext.notes
                                    where note.userID == request.userID
                                    select note)
                        .ProjectTo<NoteListDTO>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
            NoteListViewModel model = new NoteListViewModel();
            model.notes = notesQuery;
            return model;

        }

    }
}
