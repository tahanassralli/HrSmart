using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSmart.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private HrSmartContext dataContext;
        public HrSmartContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new HrSmartContext();
        }

        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }

    }
}
