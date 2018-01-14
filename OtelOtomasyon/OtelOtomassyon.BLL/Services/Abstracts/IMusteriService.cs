using OtelOtomassyon.BLL.DTOs;
using OtelOtomasyon.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Abstracts
{
   public interface IMusteriService
    {
        ResultModel<Musteri> MusteriValidate(Musteri model);
    }
}
