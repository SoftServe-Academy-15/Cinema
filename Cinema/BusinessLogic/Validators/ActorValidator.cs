using BusinessLogic.DTOs;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class ActorValidator : AbstractValidator<ActorDTO>
    {
        public ActorValidator() 
        {
            RuleFor(task => task.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(task => task.Surname)
                .NotNull()
                .NotEmpty();

            RuleFor(task => task.BirthYear)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(1800, DateTime.Now.Year)
                .WithMessage("Invalid year");
            RuleFor(task => task.PhotoUrl)
                .NotNull()
                .NotEmpty()
                .Must(IsUrl);

        }
        private static bool IsUrl(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            Uri? outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
