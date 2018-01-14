using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Concretes
{
   public class OdaTurService:IOdaTurService
    {
        private readonly IOdaTurRepository _odaTurRepository;
        public OdaTurService(IOdaTurRepository odaTurRepository)
        {
            _odaTurRepository = odaTurRepository;
        }
    }
}
