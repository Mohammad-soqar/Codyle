using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
using CodyleOfficial.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        

        public void Update(Event obj)
        {
            var objFromDb = _db.Events.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.EventLikes = obj.EventLikes;
                objFromDb.StartDate = obj.StartDate;
                objFromDb.EndDate = obj.EndDate;
                objFromDb.ScheduleUrl = obj.ScheduleUrl;
                objFromDb.Duration = obj.Duration;
                objFromDb.Slides = obj.Slides;
                objFromDb.Status = obj.Status;
                objFromDb.Type = obj.Type;
                objFromDb.YouTubeLink = obj.YouTubeLink;
                objFromDb.ApplicationCompanyId = obj.ApplicationCompanyId;
                objFromDb.Speakers = obj.Speakers;
                objFromDb.Sponsor = obj.Sponsor;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Location = obj.Location;
                objFromDb.LocationUrl = obj.LocationUrl;
                if(objFromDb.Thumbnail != null)
                {
                    objFromDb.Thumbnail = obj.Thumbnail;
                }

            }
        }
    }
}
