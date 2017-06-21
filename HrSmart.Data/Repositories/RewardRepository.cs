using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hrsmart.Domain.Entites;
using HrSmart.Data.Infrastructure;

namespace HrSmart.Data.Repositories
{
    class RewardRepository : RepositoryBase<Reward>, IRewardRepository
    {
        public RewardRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
    public interface IRewardRepository : IRepository<Reward> { }
}
