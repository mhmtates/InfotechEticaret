using Entities.DTO;
using FluentValidation;
namespace Business.ValidationRules.FluentValidation
{
    public class VariantsValidation: AbstractValidator<VariantsDto>
    {
        public VariantsValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.GroupName).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.ProductsId).NotEmpty().WithMessage("Boş Bırakılamaz.");

            RuleFor(x => x.GroupName).MaximumLength(50).WithMessage("50 Karakterden Fazla Olamaz.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("50 Karakterden Fazla Olamaz.");
        }
    }
}
