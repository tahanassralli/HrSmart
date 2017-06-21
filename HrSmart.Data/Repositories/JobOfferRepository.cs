using Hrsmart.Domain.Entites;
using HrSmart.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSmart.Data.Repositories
{
    class JobOfferRepository : RepositoryBase<JobOffer>, IJobOfferRepository
    {
        public JobOfferRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
    public interface IJobOfferRepository : IRepository<JobOffer> { }
}
