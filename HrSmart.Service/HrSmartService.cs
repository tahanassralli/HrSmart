using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hrsmart.Domain.Entites;
using HrSmart.Data.Infrastructure;

namespace HrSmart.Service
{
    public class HrSmartService : IHrSmartService
    {
        DatabaseFactory dbFactory = null;
        IUnitOfWork utOfWork = null;
        public HrSmartService()
        {
            dbFactory = new DatabaseFactory();
            utOfWork = new UnitOfWork(dbFactory);
        }


        /// <summary>
        /// Employee
        /// 

        public void CreateRecruter(Recruter p)
        {
            utOfWork.RecruterRepository.Add(p);
            utOfWork.Commit();
        }

        public Recruter GetRecruter(int recruterId)
        {
            var recruter = utOfWork.RecruterRepository.GetById(recruterId);
            return recruter;
        }


        public IEnumerable<Recruter> GetRecruters()
        {
            var recruters = utOfWork.RecruterRepository.GetAll();
            return recruters;
        }

        public IEnumerable<Recruter> GetRecruterByRole(string role)
        {
            return utOfWork.RecruterRepository.GetMany(x => x.Role == role);
        }


        //public IEnumerable<Recruter> GetRecrutersByTenantAdmin(int tenantadminid)
        //{
           // return utOfWork.RecruterRepository.GetMany(x => x.TenantAdminId == tenantadminid);
        //}

        public IEnumerable<Recruter> GetRecruterByOrganisation(string Organisationname)
        {
            return utOfWork.RecruterRepository.GetMany(x => x.organisationName == Organisationname);
        }

        public void Updaterecruter(Recruter p)
        {
            utOfWork.RecruterRepository.Update(p);
            utOfWork.Commit();
        }
        /// <summary>
        /// /////////////////////////////reffering////////////////////
        /// </summary>
        /// <param name="p"></param>
        public void CreateReffering(RefferingEmployee r)
        {
            utOfWork.RefferingRepository.Add(r);
            utOfWork.Commit();
        }

        public RefferingEmployee GetReffering(int RefferingId)
        {
            var reffering = utOfWork.RefferingRepository.GetById(RefferingId);
            return reffering;
        }


        public IEnumerable<RefferingEmployee> GetRefferings()
        {
            var refferings = utOfWork.RefferingRepository.GetAll();
            return refferings;
        }

        public IEnumerable<RefferingEmployee> GetRefferingByRole(string role)
        {
            return utOfWork.RefferingRepository.GetMany(x => x.Role == role);
        }


       // public IEnumerable<RefferingEmployee> GetRefferingsByTenantAdmin(int tenantadminid)
       // {
          //  return utOfWork.RefferingRepository.GetMany(x => x.TenantAdminId == tenantadminid);
        //}

        public IEnumerable<RefferingEmployee> GetRefferingsByOrganisation(string Organisationname)
        {
            return utOfWork.RefferingRepository.GetMany(x => x.organisationName == Organisationname);
        }

        public void Updatereffering(RefferingEmployee r)
        {
            utOfWork.RefferingRepository.Update(r);
            utOfWork.Commit();
        }


        /// <param name="Employeeid"></param>
        /// <returns></returns>


        ////////////   TenantAdmin    ///////////



        public void AddTenantAdmin(TenantAdmin t)
        {
            utOfWork.TenantAdminRepository.Add(t);
            utOfWork.Commit();
        }

        public TenantAdmin GetTenantAdmin(int TenantAdminid)
        {
            var TenantAdmin = utOfWork.TenantAdminRepository.GetById(TenantAdminid);
            return TenantAdmin;
        }
        public IEnumerable<TenantAdmin> GetTenantAdmins()
        {
            var TenantAdmins = utOfWork.TenantAdminRepository.GetAll();
            return TenantAdmins;
        }
        public IEnumerable<TenantAdmin> GetTenantAdminsByOrganisation2(string Organisationname)
        {
            return utOfWork.TenantAdminRepository.GetMany(x => x.organisationName == Organisationname);
        }

        public void UpdateTenantAdmin(TenantAdmin t)
        {
            utOfWork.TenantAdminRepository.Update(t);
            utOfWork.Commit();
        }


        /// /////////// UserInterface  ////////////////


        //public IEnumerable<UserInterface> GetUserInterfaceByTenantAdmin(int TenantAdminid)
        //{
        //    return utOfWork.UserInterfaceRepository.;
        //}

        public UserInterface GetUserInterfacebyTenantAdmin(int TenantAdminid)
        {
            var UserInterface = utOfWork.UserInterfaceRepository.GetById(TenantAdminid);
            return UserInterface;
        }


        public void UpdateUserInterface(UserInterface t)
        {
            utOfWork.UserInterfaceRepository.Update(t);
            utOfWork.Commit();
        }

        //reward
        public void CreateReward(Reward r)
        {

            utOfWork.RewardRepository.Add(r);
            utOfWork.Commit();

        }
        public IEnumerable<Reward> GetRewardsByreferringEmployee(string email)
        {

            return utOfWork.RewardRepository.GetMany(x => x.ReferringEmployee.Email == email);

        }
        public IEnumerable<Reward> GetRewards()
        {
            var Rewards = utOfWork.RewardRepository.GetAll();
            return Rewards;

        }
        public IEnumerable<Reward> GetRewardsByPoint(int point)
        {
            return utOfWork.RewardRepository.GetMany(x => x.PointNumberReward == point);

        }

        //jobOffer and condidate

        public void CreateJoboffer(JobOffer jb)
        {
            utOfWork.JobOfferRepository.Add(jb);
            utOfWork.Commit();
        }
        public IEnumerable<JobOffer> GetJoboffer()
        {
            var JobOffers = utOfWork.JobOfferRepository.GetAll();
            return JobOffers;
        }
        //IEnumerable<JobOffer> GetJobofferByrefferingEmpoyee(int idRefferingEmployee)
        //{
        //    return utOfWork.JobOfferRepository.GetMany(x => x.JobOfferID.Contains(x.));
        //        //GetMany( x.ReferringEmployees.Contains(x.j) == point);
        //}

        //public IEnumerable<ReferringEmployee> GetEmpoyeeByJobOffer(string nameJoboffer)
        // {


        // }

       // public IEnumerable<JobOffer> GetJobofferByRecuter(int idRecuter)
       // {
            //return utOfWork.JobOfferRepository.GetMany(x => x.Recuter.RecruterID == idRecuter);

       // }
        public IEnumerable<Condidate> GetCondidateByReferringEmployee(string email)
        {

            return utOfWork.CondidateRepository.GetMany(x => x.ReferringEmployee.Email == email);
        }


        public void Dispose()
        {
            utOfWork.Dispose();
        }
    }
}
