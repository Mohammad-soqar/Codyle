using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository
{
    public class SponsorRepository : Repository<Sponsor>, ISponsorRepository
    {
        private readonly ApplicationDbContext _db;
       
        public SponsorRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
            
        }

      

        public void Update(Sponsor obj)
        {
            _db.Sponsors.Update(obj);
        }
    }
}
