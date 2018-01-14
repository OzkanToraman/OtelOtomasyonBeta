using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Concretes
{
  public  class PersonelService:IPersonelService
    {
        private readonly IPersonelRepository _personelRepository;
        public PersonelService(IPersonelRepository personelRepository)
        {
            _personelRepository = personelRepository;
        }
    }
}
