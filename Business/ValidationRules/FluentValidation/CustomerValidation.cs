using Entities.DTO;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidation : AbstractValidator<CustomersUpdateDto>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.Advert).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.District).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.FullAddress).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Password).MaximumLength(30).WithMessage("30 Karakterden Fazla Olamaz.");
            RuleFor(x => x.NameSurname).MaximumLength(50).WithMessage("50 Karakterden Fazla Olamaz.");
            RuleFor(x => x.City).MaximumLength(50).WithMessage("50 Karakterden Fazla Olamaz.");
            RuleFor(x => x.District).MaximumLength(50).WithMessage("15 Karakterden Fazla Olamaz.");
            RuleFor(x => x.Phone).MaximumLength(15).WithMessage("15 Karakterden Fazla Olamaz.");
            RuleFor(x => x.FullAddress).MaximumLength(250).WithMessage("250 Karakterden Fazla Olamaz.");
            RuleFor(x => x.Phone).Must(NumberControl).WithMessage("Telefon Bilgisi Doğru Girilmedi");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("50 Karakterden Fazla Olamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("E-Mail Adresi Doğru Girilmedi.");
        }
        private bool NumberControl(string data)
        {
            Regex regex = new Regex(@"^[0-9]{10}$");
            return regex.IsMatch(data.ToString());
        }

    }
}
