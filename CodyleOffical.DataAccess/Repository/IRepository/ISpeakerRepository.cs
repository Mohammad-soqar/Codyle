using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
using CodyleOfficial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyleOffical.DataAccess.Repository.IRepository
{
    public interface ISpeakerRepository : IRepository<Speaker>
    {
        void Update(Speaker obj);


    }
}
