using System.Text.RegularExpressions;
using Entities.DTO;
using FluentValidation;
namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidation : AbstractValidator<ProductsUpdateDto>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Name).MaximumLength(150).WithMessage("Maximum 150 Karakter Yazabilirsiniz.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Boş Bırakılamaz.");
            //RuleFor(x => x.Price).Must(PriceControl).WithMessage("Fiyat Bilgisi Doğru Girilmedi");
            RuleFor(x => x.Discount).NotEmpty().When(c => c.Discount >= 0).WithMessage("0 veya 0'dan büyük Değer Giriniz.");
            //RuleFor(x => x.Discount).Must(PriceControl).WithMessage("Fiyat Bilgisi Doğru Girilmedi");
            RuleFor(x => x.Keywords).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Keywords).MaximumLength(180).WithMessage("Maximum 180 Karakter Yazabilirsiniz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Description).MaximumLength(180).WithMessage("Maximum 180 Karakter Yazabilirsiniz.");
            RuleFor(x => x.MainImages).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.CategoriesId).NotEmpty().WithMessage("Boş Bırakılamaz.");
        }
        // Overload. Metot Aşırı Yüklenmesi.
        private bool PriceControl(decimal data)
        {
            Regex regex = new Regex(@"\d{1,20}(\.\d{1,2})?");
            return regex.IsMatch(data.ToString());
        }
        private bool NumberControl(int data)
        {
            Regex regex = new Regex(@"^[0-9]{10}$");
            return regex.IsMatch(data.ToString());
        }
    }
}
