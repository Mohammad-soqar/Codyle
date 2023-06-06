using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category{ get; }
        IEventRepository Event { get; }
        IBlogRepository Blog { get; }
        IComptypeRepository CompType { get; }
        ICompanyRepository ApplicationCompany { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IServicesRepository Services { get; }
        IAttendenceRepository Attendences { get; }

        IClubMembersRepository ClubMembers { get; }
        ISponsorRepository Sponsors { get; }

        void Save();
    }
}
