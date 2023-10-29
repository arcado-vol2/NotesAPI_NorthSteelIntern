using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Queries
{
    internal class GetNoteBodyQueryValidator : AbstractValidator<GetNoteBodyQuery>
    {
        GetNoteBodyQueryValidator()
        {
            RuleFor(note => note.ID).NotEqual(Guid.Empty);
            RuleFor(note => note.userID).NotEqual(Guid.Empty);
        }
    }
}
