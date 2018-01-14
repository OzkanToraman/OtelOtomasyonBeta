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
    public class KatRepository : EFRepositoryBase<Kat, ProjectContext>,IKatRepository 
    {
        public KatRepository(DbContext Context) : base(Context)
        {

        }
    }
}
