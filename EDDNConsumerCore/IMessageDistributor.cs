using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDNConsumerCore
{
    public interface IMessageDistributor
    {
        Task DistributeAsync(string message);
    }
}
