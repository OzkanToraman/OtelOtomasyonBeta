using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Concretes
{
   public class KatService:IKatService
    {
        private readonly IKatRepository _katRepository;
        public KatService(IKatRepository katRepository)
        {
            _katRepository = katRepository;
        }
    }
}
