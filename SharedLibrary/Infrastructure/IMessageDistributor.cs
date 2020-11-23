using EDDNModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Infrastructure
{
    public interface IMessageDistributor
    {
        Task DistributeAsync(string message);
    }
}
