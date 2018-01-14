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
using OtelOtomasyon.Repository.UOW.Abstract;

namespace OtelOtomassyon.BLL.Services.Concretes
{
    public class MusteriService : IMusteriService
    {
        protected IUnitOfWork _uow;
        private readonly IMusteriRepository _musteriRepository;
        public MusteriService(IMusteriRepository musteriRepository, IUnitOfWork uow)
        {
            _uow = uow;
            _musteriRepository = musteriRepository;
        }

        public ResultModel<Musteri> MusteriValidate(Musteri model)
        {

            var validator = new MusteriValidator().Validate(model);
            if (validator.IsValid)
            {
                _uow.GetRepo<Musteri>().Add(model);
                _uow.Commit();
                return new ResultModel<Musteri>
                {
                    Errors = null,
                    IsValid = true,
                    Message = "İşlem başarılı!"
                };
            }
            else
            {
                return new ResultModel<Musteri>
                {
                    Errors = validator.Errors.Select(x => x.ErrorMessage).ToList(),
                    IsValid = false,
                    Message = "İşlem başarısız!"
                };
            }
        }
    }
}
