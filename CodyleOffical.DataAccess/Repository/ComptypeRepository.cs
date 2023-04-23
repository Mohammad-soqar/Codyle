using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository
{
    public class ComptypeRepository : Repository<CompType>, IComptypeRepository
    {
        private readonly ApplicationDbContext _db;
       
        public ComptypeRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
            
        }

      

        public void Update(CompType obj)
        {
            _db.CompTypes.Update(obj);
        }
    }
}
