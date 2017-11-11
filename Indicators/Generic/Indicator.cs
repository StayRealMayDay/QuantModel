using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuantModel.Indicators.Generic
{

    public class Indicator : IIndicator
    {
        public event Action Update;

        protected virtual void FollowUp() => Update?.Invoke();

        public IEnumerable<object> GetNexts() => Update?.GetInvocationList().Select(i => i.Target) ?? Enumerable.Empty<object>();

    }
    
    public class Indicator<T> : Indicator, IIndicator<T>
    {
        protected List<T> Data { get; } = new List<T>();

        public IEnumerator<T> GetEnumerator() => Data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => Data.Count;

        public T this[int index] => Data[index];
    }
}