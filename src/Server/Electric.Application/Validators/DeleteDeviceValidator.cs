using Electric.Application.Commands;
using FluentValidation;

namespace Electric.Application.Validators
{
    public class DeleteDeviceValidator : AbstractValidator<DeleteDeviceCommand>
    {
        public DeleteDeviceValidator()
        {
            RuleFor(x => x.Id)
                 .NotNull()
                .NotEmpty();
        }
    }
}
