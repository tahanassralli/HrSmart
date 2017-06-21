using HrSmart.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSmart.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private HrSmartContext dataContext;
        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        private IRefferingRepository refferingRepository;
        public IRefferingRepository RefferingRepository
        {
            get { return refferingRepository = new RefferingRepository(dbFactory); }
        }
        private IRecruterRepository recruterRepository;
        public IRecruterRepository RecruterRepository
        {
            get { return recruterRepository = new RecruterRepository(dbFactory); }
        }
        private ICondidateRepository condidateRepository;
        public ICondidateRepository CondidateRepository
        {
            get { return condidateRepository = new CondidateRepository(dbFactory); }
        }


        private IJobOfferRepository jobOfferRepository;
        public IJobOfferRepository JobOfferRepository
        {
            get { return jobOfferRepository = new JobOfferRepository(dbFactory); }
        }


        private IRewardRepository rewardRepository;
        public IRewardRepository RewardRepository
        {
            get { return rewardRepository = new RewardRepository(dbFactory); }
        }
        private ITenantAdminRepository tenantAdminRepository;
        public ITenantAdminRepository TenantAdminRepository
        {
            get { return tenantAdminRepository = new TenantAdminRepository(dbFactory); }
        }

        private IUserInterfaceRepository userInterfaceRepository;
        public IUserInterfaceRepository UserInterfaceRepository
        {
            get { return userInterfaceRepository = new UserInterfaceRepository(dbFactory); }
        }


        protected HrSmartContext DataContext
        {
            get
            {
                return dataContext = dbFactory.DataContext;
            }
        }
        public void Commit()
        {
            DataContext.SaveChanges();
        }
        public void Dispose()
        {
            dbFactory.Dispose();
        }


    }
}
