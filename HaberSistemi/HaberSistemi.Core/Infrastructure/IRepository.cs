﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HaberSistemi.Core.Infrastructure
{
    public interface IRepository<I> where I : class
    {
        IEnumerable<I> GetAll();
        I GetById(int id);
        I Get(Expression<Func<I, bool>> expression);
        IQueryable<I> GetMany(Expression<Func<I, bool>> expression);
        void Insert(I obj);
        void Update(I obj);
        void Delete(int id);
        int Count();
        void Save();



    }
}
