﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Cargo.DataAccessLayer.Abstract
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
