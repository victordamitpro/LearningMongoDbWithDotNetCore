using Electric.Application.Commands;
using FluentValidation;

namespace Electric.Application.Validators
{
    public class UpdateDeviceValidator : AbstractValidator<UpdateElectricMetterCommand>
    {
        public UpdateDeviceValidator()
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
