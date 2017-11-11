using System.Collections.Generic;

namespace QuantModel.Indicators.Generic
{
    public class Dumb<T> : Indicator<T>
    {
        public void Add(T item)
        {
            Data.Add(item);
            FollowUp();
        }
        public void AddRange(IEnumerable<T> items) 
        {
            items
            Data.AddRange(items);
            FollowUp();
        }
        public override string ToString() => $"Dumb({Count})";
    }
}