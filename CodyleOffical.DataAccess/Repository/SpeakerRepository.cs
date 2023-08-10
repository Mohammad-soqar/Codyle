using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
using CodyleOfficial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository
{
    public class SpeakerRepository : Repository<Speaker>, ISpeakerRepository
    {
        private readonly ApplicationDbContext _db;
       
        public SpeakerRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
            
        }


        public void Update(Speaker obj)
        {
            var objFromDb = _db.Speakers.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.LinkedIn = obj.LinkedIn;
                objFromDb.Instagram = obj.Instagram;
                objFromDb.Behance = obj.Behance;
                objFromDb.PersonalWebsite = obj.PersonalWebsite;
              
                if(objFromDb.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}
