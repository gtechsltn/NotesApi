using FluentValidation;

namespace NotesApi.CreateNotes
{
    public class CreateNotesValidator : Validator<CreateNotes>
    {
        public CreateNotesValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty()
                .WithMessage("User Id is Mandatory.");
            RuleFor(p => p.Content)
               .NotEmpty()
               .WithMessage("There is not content for Notes.");
        }
    }
}
