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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Event = new EventRepository(_db);
            Blog = new BlogRepository(_db);
            CompType = new ComptypeRepository(_db);
            ApplicationCompany = new CompanyRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            Services = new ServicesRepository(_db);
            Speaker = new SpeakerRepository(_db);
            Attendences = new AttendenceRepository(_db);
            ClubMembers = new ClubMembersRepository(_db);
            Sponsors = new SponsorRepository(_db);
            EventLike = new EventLikeRepository(_db);

        }

        public ICategoryRepository Category {get; private set;}
        public IEventRepository Event { get; private set; }
        public IBlogRepository Blog { get; private set; }
        public IComptypeRepository CompType { get; private set; }
        public ICompanyRepository ApplicationCompany { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IServicesRepository Services { get; private set; }
        public IAttendenceRepository Attendences { get; private set; }
        public IClubMembersRepository ClubMembers { get; private set; }
        public ISponsorRepository Sponsors { get; private set; }
        public ISpeakerRepository Speaker { get; private set; }
        public IEventLikeRepository EventLike { get; private set; }

        public IEnumerable<Speaker> GetSpeakersByEventId(int eventId)
        {
            string query = "SELECT Speakers.* " +
                           "FROM Speakers " +
                           "JOIN EventSpeakers ON EventSpeakers.SpeakersId = Speakers.Id " +
                           "WHERE EventSpeakers.EventsId = @eventId";

            return _db.Speakers.FromSqlRaw(query, new SqlParameter("@eventId", eventId)).ToList();
        }

        public void Save()
        {
           _db.SaveChanges();
        }
    }
}
