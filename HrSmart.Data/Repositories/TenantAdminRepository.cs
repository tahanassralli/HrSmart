using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hrsmart.Domain.Entites;
using HrSmart.Data.Infrastructure;

namespace HrSmart.Data.Repositories
{
    public class TenantAdminRepository : RepositoryBase<TenantAdmin>, ITenantAdminRepository
    {
        public TenantAdminRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
    public interface ITenantAdminRepository : IRepository<TenantAdmin> { }
}
