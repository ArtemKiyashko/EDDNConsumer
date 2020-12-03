using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubSender
{
    public interface IDataReader<TOut>
    {
        TOut ReadData();
    }
}
