using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubSender.Adapters
{
    public interface IModelAdapter<TIn, TOut>
    {
        TOut Adapt(TIn input);
    }
}
