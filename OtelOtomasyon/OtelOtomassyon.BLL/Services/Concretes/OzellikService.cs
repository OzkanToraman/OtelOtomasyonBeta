using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Concretes
{
   public class OzellikService :IOzellikService
    {
        private readonly IOzellikRepository _ozellikRepository;
        public OzellikService(IOzellikRepository ozellikRepository)
        {
            _ozellikRepository = ozellikRepository;
        }
    }
}
