using Entities.DTO;
using FluentValidation;
namespace Business.ValidationRules.FluentValidation
{
    public class OrderInfovalidation: AbstractValidator<OrderInfoDto>
    {
        public OrderInfovalidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Sms).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.InfoDate).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.OrdersId).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.CustomersId).NotEmpty().WithMessage("Boş Bırakılamaz.");

            RuleFor(x => x.Message).MaximumLength(150).WithMessage("150 Karakterden Fazla Olamaz.");

        }
    }
}
