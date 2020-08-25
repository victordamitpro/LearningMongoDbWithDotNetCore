using Electric.Application.Commands;
using FluentValidation;

namespace Electric.Application.Validators
{
    public class CreateDeviceValidator : AbstractValidator<CreateElectricMetterCommand>
    {
        public CreateDeviceValidator()
        {
            RuleFor(x => x.FirmwareVersion)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.SeriaNumber)
                .NotNull()
               .NotEmpty();
        }
    }
}
