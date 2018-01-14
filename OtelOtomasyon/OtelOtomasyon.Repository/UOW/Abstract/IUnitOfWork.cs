using OtelOtomasyon.Core.Abstract;
using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.Repository.UOW.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        IRepository<T> GetRepo<T>() where T : BaseEntity, new();

        void Dispose(bool disposing);
    }
}
