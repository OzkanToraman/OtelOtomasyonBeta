using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Concretes
{
   public class SatisService:ISatisService
    {
        private readonly ISatisRepository _satisRepository;
        public SatisService(ISatisRepository satisRepository)
        {
            _satisRepository = satisRepository;
        }
    }
}
