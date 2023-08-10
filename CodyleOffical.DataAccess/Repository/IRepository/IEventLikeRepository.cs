using CodyleOfficial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository.IRepository
{
    public interface IEventLikeRepository : IRepository<EventLike>
    {
        void Update(EventLike obj);
     
    }
}
