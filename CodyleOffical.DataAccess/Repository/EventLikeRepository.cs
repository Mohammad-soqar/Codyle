using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using CodyleOfficial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository
{
    public class EventLikeRepository : Repository<EventLike>, IEventLikeRepository
    {
        private readonly ApplicationDbContext _db;
       
        public EventLikeRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
            
        }

      

        public void Update(EventLike obj)
        {
            _db.EventLike.Update(obj);
        }
    }
}
