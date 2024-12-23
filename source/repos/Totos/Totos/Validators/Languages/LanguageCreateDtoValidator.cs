using FluentValidation;
using Totos.DTOs.Languages;

namespace Totos.Validators.Languages
{
    public class LanguageCreateDtoValidator:AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code bos ola bilmez")
                .NotNull().WithMessage("Code null ola bilmez")
                .Length(2).WithMessage("Code uzunlugu 2e beraber olmalidir");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad bos ola bilmez")
                .NotNull().WithMessage("Ad null ola bilmez")
                .MaximumLength(32).WithMessage("Ad uzunlugu 32den cox ola bilmez")
                .MinimumLength(3).WithMessage("Ad uzunlugu 3den az ola bilmez");

            RuleFor(x => x.IconUrl)
                .MaximumLength (256).WithMessage("Link uzunlugu 128den cox ola bilmez")
                .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
                .WithMessage("Url link olmalidir");

        }
    }
}
