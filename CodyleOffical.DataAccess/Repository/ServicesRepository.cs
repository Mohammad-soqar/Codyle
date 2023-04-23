using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository
{
    public class ServicesRepository : Repository<Services>, IServicesRepository
    {
        private readonly ApplicationDbContext _db;
       
        public ServicesRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
            
        }

      
        public void Update(Services obj)
        {
            var objFromDb = _db.Service.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.BusinessName = obj.BusinessName;
                objFromDb.FavoritewebUrl1 = obj.FavoritewebUrl1;
                objFromDb.FavoritewebUrl2 = obj.FavoritewebUrl2;
                objFromDb.FavoritewebUrl3 = obj.FavoritewebUrl3;
                objFromDb.WebsiteUrl = obj.WebsiteUrl;
                objFromDb.Budget = obj.Budget;




            }
        }
    }
}
