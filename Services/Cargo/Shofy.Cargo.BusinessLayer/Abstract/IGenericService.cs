﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T:class
    {
        void TAdd(T entity);
        void TDelete(int id);
        void TUpdate(T entity);
        T TGetById(int id);
        List<T> TGetAll();
    }

}
