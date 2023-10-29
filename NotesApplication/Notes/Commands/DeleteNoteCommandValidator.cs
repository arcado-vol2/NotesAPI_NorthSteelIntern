using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Commands
{
    public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator() 
        {
            RuleFor(deleteNoteCommand => deleteNoteCommand.userID).NotEqual(Guid.Empty);
            RuleFor(deleteNoteCommand => deleteNoteCommand.ID).NotEqual(Guid.Empty);
        }
    }
}
