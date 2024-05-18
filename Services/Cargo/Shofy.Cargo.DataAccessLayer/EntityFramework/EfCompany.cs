﻿using Shofy.Cargo.DataAccessLayer.Abstract;
using Shofy.Cargo.DataAccessLayer.Concrete;
using Shofy.Cargo.DataAccessLayer.Context;
using Shofy.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCompany : Repository<Company>, ICompanyRepository
    {
        public EfCompany(CargoDbContext context) : base(context)
        {
        }
    }
}