using CodyleOffical.DataAccess.Repository.IRepository;
using CodyleOffical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        private readonly ApplicationDbContext _db;
       
        public BlogRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
            
        }

      
        public void Update(Blog obj)
        {
            var objFromDb = _db.Blogs.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.blogContent = obj.blogContent;
                objFromDb.CategoryId = obj.CategoryId;
              
                if(objFromDb.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}
