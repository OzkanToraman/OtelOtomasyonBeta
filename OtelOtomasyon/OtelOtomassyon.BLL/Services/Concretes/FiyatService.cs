using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Concretes
{
   public  class FiyatService:IFiyatService
    {
        private readonly IFiyatRepository _fiyatRepository;
        public FiyatService(IFiyatRepository fiyatRepository)
        {
            _fiyatRepository = fiyatRepository;
        }
    }
}
