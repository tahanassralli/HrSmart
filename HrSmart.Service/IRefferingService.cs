using Hrsmart.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSmart.Service
{
    public interface IRefferingService
    {
        void Add(RefferingEmployee re);
        void Delete(int id);
        IEnumerable<RefferingEmployee> GetAll();
        RefferingEmployee GetById(int id);
        
        void Update(RefferingEmployee re);
    }
}
