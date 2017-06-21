using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hrsmart.Domain.Entites;
using HrSmart.Data.Infrastructure;

namespace HrSmart.Data.Repositories
{
    public class UserInterfaceRepository : RepositoryBase<UserInterface>, IUserInterfaceRepository
    {
        public UserInterfaceRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }

    }
    public interface IUserInterfaceRepository : IRepository<UserInterface> { }
}
