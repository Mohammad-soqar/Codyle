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
    public class ClubMembersRepository : Repository<ClubMembers>, IClubMembersRepository
    {
        private readonly ApplicationDbContext _db;
       
        public ClubMembersRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
            
        }

      

        public void Update(ClubMembers obj)
        {
            _db.ClubMember.Update(obj);
        }
    }
}
