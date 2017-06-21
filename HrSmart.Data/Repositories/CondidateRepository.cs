using Hrsmart.Domain.Entites;
using HrSmart.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSmart.Data.Repositories
{
    public class CondidateRepository : RepositoryBase<Condidate>, ICondidateRepository
    {
        public CondidateRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
    public interface ICondidateRepository : IRepository<Condidate> { }
}
