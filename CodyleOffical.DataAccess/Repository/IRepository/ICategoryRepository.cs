﻿using CodyleOffical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<ApplicationCompany>
    {
        void Update(ApplicationCompany obj);
     
    }
}
