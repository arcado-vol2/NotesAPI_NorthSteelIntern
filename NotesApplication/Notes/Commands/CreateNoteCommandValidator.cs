using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Commands
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator() 
        {
            RuleFor(creteNoteCommand => creteNoteCommand.head).NotEmpty().MaximumLength(128);
            RuleFor(creteNoteCommand => creteNoteCommand.userID).NotEqual(Guid.Empty);
        }
    }
}
