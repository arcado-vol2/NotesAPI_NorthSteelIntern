using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Queries
{
    public class GetNotesListQuery : IRequest<NoteListViewModel>
    {
        public Guid userID { get; set; }

    }
}
