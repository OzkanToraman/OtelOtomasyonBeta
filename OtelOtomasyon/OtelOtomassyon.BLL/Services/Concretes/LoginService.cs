using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtelOtomassyon.BLL.DTOs;
using OtelOtomasyon.DAL;
using OtelOtomassyon.BLL.Validations;

namespace OtelOtomassyon.BLL.Services.Concretes
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public ResultModel<Login> LoginControl(Login model)
        {
            var validator = new LoginValidator().Validate(model);
            if (validator.IsValid)
            {
                    return new ResultModel<Login>
                    {
                        Errors = null,
                        IsValid = true,
                        Message = "İşlem başarılı"
                    };
                
            }
            return new ResultModel<Login>
            {
                Errors = validator.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Kullanıcı adı ya da şifre yanlış!"
            };
        }
    }
}
