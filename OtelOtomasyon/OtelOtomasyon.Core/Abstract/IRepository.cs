﻿using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.Core.Abstract
{
    public interface IRepository<T>
        where T:BaseEntity, new()
    {
        void Add(T model);

        void Update(T model);

        void Delete(int id);

        IEnumerable<T> GetList();

        T GetById(int id);

        IEnumerable<T> Where(Expression<Func<T, bool>> lambda);

        IQueryable<T> WhereByQuery(Expression<Func<T, bool>> lambda);

     
    }
}
