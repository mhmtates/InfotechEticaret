using Entities.DTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderNotesValidation: AbstractValidator<OrderNotesDto>
    {
        public OrderNotesValidation()
        {
            RuleFor(x => x.OrdersId).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.NotDate).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Notes).NotEmpty().WithMessage("Boş Bırakılamaz.");

            RuleFor(x => x.Notes).MaximumLength(150).WithMessage("150 Karakterden Fazla Olamaz.");
        }
    }
}
