using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hrsmart.Domain.Entites;
using HrSmart.Data.Infrastructure;

namespace HrSmart.Data.Repositories
{
    public class RefferingRepository : RepositoryBase<RefferingEmployee>, IRefferingRepository
    {
        public RefferingRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
    public interface IRefferingRepository : IRepository<RefferingEmployee> { }
}
