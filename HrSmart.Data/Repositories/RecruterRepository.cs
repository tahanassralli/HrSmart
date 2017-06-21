using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hrsmart.Domain.Entites;
using HrSmart.Data.Infrastructure;

namespace HrSmart.Data.Repositories
{
    public class RecruterRepository : RepositoryBase<Recruter>, IRecruterRepository
    {
        public RecruterRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
    public interface IRecruterRepository : IRepository<Recruter> { }
}
