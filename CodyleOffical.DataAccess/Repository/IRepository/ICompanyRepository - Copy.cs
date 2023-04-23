using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository.IRepository
{
    public interface IClubMembersRepository : IRepository<ClubMembers>
    {
        void Update(ClubMembers obj);
     
    }
}
