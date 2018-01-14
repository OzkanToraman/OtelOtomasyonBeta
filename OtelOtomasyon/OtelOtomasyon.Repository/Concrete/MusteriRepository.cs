using OtelOtomasyon.Core.Concrete;
using OtelOtomasyon.DAL;
using OtelOtomasyon.DAL.Entities;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.Repository.Concrete
{
    public class MusteriRepository : EFRepositoryBase<Musteri, ProjectContext>, IMusteriRepository
    {
        public MusteriRepository(DbContext Context) : base(Context)
        {

        }

        public int SonMusteriIdBul()
        {
            return _dbContext.Set<Musteri>().OrderByDescending(x => x.Id).FirstOrDefault().Id;
        }
    }
}
