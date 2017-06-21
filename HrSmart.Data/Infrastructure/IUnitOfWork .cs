using HrSmart.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSmart.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        ICondidateRepository CondidateRepository { get; }
        IRefferingRepository RefferingRepository { get; }
        IRecruterRepository RecruterRepository { get; }
        IJobOfferRepository JobOfferRepository { get; }
        IRewardRepository RewardRepository { get; }
        ITenantAdminRepository TenantAdminRepository { get; }
        IUserInterfaceRepository UserInterfaceRepository { get; }

    }
}
