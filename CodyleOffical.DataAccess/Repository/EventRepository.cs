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
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly ApplicationDbContext _db;
       
        public EventRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
            
        }

        public int DecrementCount(Event Event, int count)
        {
            Event.NumberOfTickets -= count;
            return Event.NumberOfTickets;
        }

        public int IncrementCount(Event Event, int count)
        {
            Event.NumberOfTickets += count;
            return Event.NumberOfTickets;
        }

        public void Update(Event obj)
        {
            var objFromDb = _db.Events.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.Slides = obj.Slides;
                objFromDb.Finished = obj.Finished;

                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Date = obj.Date;
                objFromDb.Location = obj.Location;
                objFromDb.LocationUrl = obj.LocationUrl;
                if(objFromDb.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}
