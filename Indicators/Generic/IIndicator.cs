using System;
using System.Collections.Generic;

namespace QuantModel.Indicators.Generic
{
    public interface IIndicator
    {
        event Action Update;
    }

    public interface IIndicator<out T>: IIndicator, IReadOnlyList<T>
    {
        
    }
}