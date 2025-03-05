using FluentValidation;

namespace Domain.DTOS
{
    public class EnrollmentDtoValidator : AbstractValidator<EnrollmentDto>
    {
        public EnrollmentDtoValidator()
        {
            RuleFor(x => x.StudentId).NotEmpty().WithMessage("Student ID is required.");

            RuleFor(x => x.ClassId).NotEmpty().WithMessage("Class ID is required.");

            RuleFor(x => x.EnrollmentDate).NotEmpty().WithMessage("Enrollment date is required.");
        }
    }
}