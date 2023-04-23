using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository
{
    public class AttendenceRepository : Repository<Attendence>, IAttendenceRepository
    {
        private readonly ApplicationDbContext _db;
       
        public AttendenceRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
            
        }

    

        public void Update(Attendence obj)
        {
            var objFromDb = _db.Attendences.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.LastName = obj.LastName;
            
            }
        }
    }
}
