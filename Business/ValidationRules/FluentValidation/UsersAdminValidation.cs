using Entities.DTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UsersAdminValidation: AbstractValidator<UsersAdminDto>
    {
        public UsersAdminValidation()
        {
            RuleFor(x => x.NameSurName).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.EPosta).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Roles).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş Bırakılamaz.");

            RuleFor(x => x.Roles).MaximumLength(25).WithMessage("25 Karakterden Fazla Olamaz.");
            RuleFor(x => x.EPosta).MaximumLength(80).WithMessage("80 Karakterden Fazla Olamaz.");
            RuleFor(x => x.Phone).MaximumLength(50).WithMessage("15 Karakterden Fazla Olamaz.");
            RuleFor(x => x.NameSurName).MaximumLength(50).WithMessage("50 Karakterden Fazla Olamaz.");
            RuleFor(x => x.Password).MaximumLength(30).WithMessage("30 Karakterden Fazla Olamaz.");
        }
    }
}
