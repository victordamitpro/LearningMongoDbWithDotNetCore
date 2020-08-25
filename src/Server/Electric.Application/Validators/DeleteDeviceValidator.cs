using Electric.Application.Commands;
using FluentValidation;

namespace Electric.Application.Validators
{
    public class DeleteDeviceValidator : AbstractValidator<DeleteElectricMetterCommand>
    {
        public DeleteDeviceValidator()
        {
            RuleFor(x => x.Id)
                 .NotNull()
                .NotEmpty();
        }
    }
}
