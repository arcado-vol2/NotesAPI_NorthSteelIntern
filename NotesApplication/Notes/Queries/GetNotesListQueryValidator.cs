using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Queries
{
    public class GetNotesListQueryValidator :AbstractValidator<GetNotesListQuery>
    {
        public GetNotesListQueryValidator() 
        { 
            RuleFor(note => note.userID).NotEqual(Guid.Empty);
        }
    }
}
