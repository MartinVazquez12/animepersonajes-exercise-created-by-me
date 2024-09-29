using animepersonajesWebApi.Dtos;
using FluentValidation;

namespace animepersonajesWebApi.Validators
{
    public class PersonajePostDtoValidator : AbstractValidator<PersonajePostDto>
    {
        public PersonajePostDtoValidator()
        {
            RuleFor(x => x.nombrepost)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5).WithMessage("Minimo 5 Caracteres");
            RuleFor(x => x.ocupost)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50).WithMessage("Largo maximo 50");
            RuleFor(x => x.locpost)
                .NotEmpty();
            RuleFor(x => x.edadpost)
                .NotEmpty();
            RuleFor(x => x.generopost)
                .NotEmpty();
            RuleFor(x=> x.id_animepost)
                .NotEmpty();
        }
    }
}
