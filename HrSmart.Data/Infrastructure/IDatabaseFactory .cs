using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSmart.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        HrSmartContext DataContext { get; }

    }
}
