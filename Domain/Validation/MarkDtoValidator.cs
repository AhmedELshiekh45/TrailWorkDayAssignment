using FluentValidation;

namespace Domain.DTOS
{
    public class MarkDtoValidator : AbstractValidator<MarkDto>
    {
        public MarkDtoValidator()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty().WithMessage("Student ID is required.");

            RuleFor(x => x.ClassId)
                .NotEmpty().WithMessage("Class ID is required.");

            RuleFor(x => x.ExamMark)
                .InclusiveBetween(0, 100).WithMessage("Exam mark must be between 0 and 100.");

            RuleFor(x => x.AssignmentMark)
                .InclusiveBetween(0, 100).WithMessage("Assignment mark must be between 0 and 100.");
        }
    }
}