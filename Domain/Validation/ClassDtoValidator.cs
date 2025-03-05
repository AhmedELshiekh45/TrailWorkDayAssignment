using FluentValidation;

namespace Domain.DTOS
{
    public class ClassDtoValidator : AbstractValidator<ClassDto>
    {
        public ClassDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                                .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters.");

            RuleFor(x => x.Teacher).NotEmpty().WithMessage("Teacher is required.")
                                   .MaximumLength(100).WithMessage("Teacher name cannot be longer than 100 characters.");

            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description cannot be longer than 500 characters.");
        }
    }
}