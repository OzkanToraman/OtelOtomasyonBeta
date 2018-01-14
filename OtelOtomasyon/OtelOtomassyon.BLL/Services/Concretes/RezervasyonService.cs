using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Concretes
{
   public  class RezervasyonService:IRezervasyonService
    {
        private readonly IRezervasyonRepository _rezervasyonRepository;
        public RezervasyonService(IRezervasyonRepository rezervasyonRepository)
        {
            _rezervasyonRepository = rezervasyonRepository;
        }
    }
}
