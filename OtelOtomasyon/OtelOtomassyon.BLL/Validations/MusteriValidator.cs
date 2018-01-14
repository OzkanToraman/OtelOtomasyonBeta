using FluentValidation;
using OtelOtomasyon.DAL;
using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Validations
{
   public class MusteriValidator:AbstractValidator<Musteri>
    {
        public MusteriValidator()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Ad alanı boş geçilemez!");
            RuleFor(x => x.Soyad).NotEmpty().WithMessage("Soyad alanı boş geçilemez!");
            RuleFor(x => x.TCNo).NotEmpty().WithMessage("Kimlik alanı boş geçilemez!");
            RuleFor(x => x.TCNo).Must(IsOnlyDigit).WithMessage("Kimlik numarasını yanlış ya da eksik girdiniz!");
            RuleFor(x => x.TCNo).MinimumLength(11).WithMessage("Kimlik numaranızı eksik girdiniz!");
            RuleFor(x => x.Telefon).NotEmpty().WithMessage("Telefon alanı boş geçilemez!");
            RuleFor(x => x.DogumTarihi).NotEmpty().WithMessage("Doğum Tarih alanı boş geçilemez!");
            RuleFor(x => x.Adres).NotEmpty().WithMessage("Adres alanı boş geçilemez!");
        }

        bool IsOnlyDigit(string TCNo)
        {
            foreach (char c in TCNo)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
