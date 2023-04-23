using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository
{
    public class BlogCartRepository : Repository<BlogCart>, IBlogCartRepository
    {
        private readonly ApplicationDbContext _db;
       
        public BlogCartRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
            
        }

     
    }
}
