using CodyleOffical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository.IRepository
{
    public interface IComptypeRepository : IRepository<CompType>
    {
        void Update(CompType obj);
     
    }
}
