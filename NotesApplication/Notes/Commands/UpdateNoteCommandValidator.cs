using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Commands
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.head).NotEmpty().MaximumLength(128);
            RuleFor(updateNoteCommand => updateNoteCommand.userID).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand => updateNoteCommand.ID).NotEqual(Guid.Empty);
        }
    }
}
