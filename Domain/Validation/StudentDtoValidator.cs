using FluentValidation;

namespace Domain.DTOS
{
    public class StudentDtoValidator : AbstractValidator<StudentDto>
    {
        public StudentDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.")
                                     .MaximumLength(50).WithMessage("First name cannot be longer than 50 characters.");

            RuleFor(x => x.LasttName).NotEmpty().WithMessage("Last name is required.")
                                     .MaximumLength(50).WithMessage("Last name cannot be longer than 50 characters.");

            RuleFor(x => x.Age).InclusiveBetween(5, 100).WithMessage("Age must be between 5 and 100.");
        }
    }
}