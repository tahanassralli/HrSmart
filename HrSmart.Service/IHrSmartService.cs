using Hrsmart.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSmart.Service
{
    public interface IHrSmartService : IDisposable
    {
        //  Employee


        void CreateRecruter(Recruter p);
        Recruter GetRecruter(int recruterId);
        IEnumerable<Recruter> GetRecruters();
        IEnumerable<Recruter> GetRecruterByRole(string role);
        //IEnumerable<Recruter> GetRecrutersByTenantAdmin(int tenantadminid);
        IEnumerable<Recruter> GetRecruterByOrganisation(string Organisationname);
        void Updaterecruter(Recruter p);
        void CreateReffering(RefferingEmployee r);
        RefferingEmployee GetReffering(int RefferingId);
        IEnumerable<RefferingEmployee> GetRefferings();
        IEnumerable<RefferingEmployee> GetRefferingByRole(string role);
       // IEnumerable<RefferingEmployee> GetRefferingsByTenantAdmin(int tenantadminid);
        IEnumerable<RefferingEmployee> GetRefferingsByOrganisation(string Organisationname);
        void Updatereffering(RefferingEmployee r);


        //TenantAdmin 

        void AddTenantAdmin(TenantAdmin t);
        TenantAdmin GetTenantAdmin(int TenantAdminid);
        IEnumerable<TenantAdmin> GetTenantAdmins();
        IEnumerable<TenantAdmin> GetTenantAdminsByOrganisation2(string Organisationname);

        void UpdateTenantAdmin(TenantAdmin t);

        // UserInterface 
        UserInterface GetUserInterfacebyTenantAdmin(int TenantAdminid);
        void UpdateUserInterface(UserInterface u);
        //reward 

        void CreateReward(Reward r);
        IEnumerable<Reward> GetRewardsByreferringEmployee(string email);
        IEnumerable<Reward> GetRewards();


        // Reward GetReward(int idReward);
        IEnumerable<Reward> GetRewardsByPoint(int point);

        //jobOffer and condidate

        void CreateJoboffer(JobOffer jb);
        IEnumerable<JobOffer> GetJoboffer();
        //IEnumerable<JobOffer> GetJobofferByRecuter(int idRecuter);
        // IEnumerable<JobOffer> GetJobofferByrefferingEmpoyee(int idRefferingEmployee);
        //IEnumerable<ReferringEmployee> GetEmpoyeeByJobOffer(string nameJoboffer);
        //IEnumerable<Condidate> GetCondidateByJobOffer(string namejobOffer);
        IEnumerable<Condidate> GetCondidateByReferringEmployee(string email);



    }
}
