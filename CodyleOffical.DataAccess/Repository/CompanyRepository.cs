using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository
{
    public class CompanyRepository : Repository<ApplicationCompany>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;
       
        public CompanyRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
            
        }

      

        public void Update(ApplicationCompany obj)
        {
            _db.ApplicationCompanies.Update(obj);
        }
    }
}
