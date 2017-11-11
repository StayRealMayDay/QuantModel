using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace QuantModel.Indicators.Generic
{
    public class LiveSelector<T1, T2> : Indicator, IIndicator<T2>
    {
        public LiveSelector(IIndicator<T1> source, Func<T1, int, T2> selector)
        {
            Source = source;
            Selector = selector;
            Source.Update += FollowUp;
        }

        public T2 this[int index] => Selector(Source[index],index);

        public int Count => Source.Count;

        public event Action Update;

        public IEnumerator<T2> GetEnumerator() => Source.Select(Selector).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        private IIndicator<T1> Source { get; }
        private Func<T1, int, T2> Selector;
    }
}
