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
   public class LoginValidator:AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
        }
    }
}
