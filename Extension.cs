using System;
using System.Collections.Generic;
using System.Linq;
using QuantModel.Indicators;
using QuantModel.Indicators.Generic;

namespace QuantModel
{
    public static class Extension
    {
        public static void AddRange<T>(this Dumb<T> source, params T[] items) => source.AddRange(items.AsEnumerable());

        public static void AddRange<T>(this Dumb<T> source, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                source.Add(item);
            }
        }
        public static EMA EMA(this IIndicator<double> source, int cycle) => new EMA(source, cycle);
        public static SMA SMA(this IIndicator<double> source, int cycle) => new SMA(source, cycle);
        public static MACD MACD(this IIndicator<double> source, int fast, int slow, int dif) => new MACD(source, fast, slow, dif);
        public static StandardDeviation StdDev(this IIndicator<double> source, int cycle) => new StandardDeviation(source, cycle);
        public static StandardDeviation StdDev(this IIndicator<double> source, int cycle, IIndicator<double> average) => new StandardDeviation(source,average, cycle);
        public static ROI ROI(this IIndicator<double> source) => new ROI(source);

        public static IEnumerable<int> Range(int left, int right)
        {
            for (var i = left; i < right; i++)
            {
                yield return i;
            }
        }
        public static IEnumerable<int> RangeRight(int left, int right)
        {
            for (var i = right - 1; i >= left; i--)
            {
                yield return i;
            }
        }


        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void FillRange<T>(this List<T> source, int left, int right, Func<int, T> func)
        {
            source.AddRange(Enumerable.Repeat(default(T), right - source.Count));
            Range(left, right).ForEach(i =>
            {
                source[i] = func(i);
            });
        }

        public static IEnumerable<int> StartAt(int start)
        {
            for (var i = start; ; i++)
            {
                yield return i;
            }
        }


        public static void PrintTree(Indicator node, int dep, Dictionary<Indicator, int> order, ref int cnt)
        {
            Range(0, dep).ForEach(ii => Console.Write("  "));
            if (order.ContainsKey(node))
            {
                Console.WriteLine($"[ref][{order[node]}]");
            }
            else
            {
                Console.WriteLine($"[{cnt}]{node}");
                order.Add(node, cnt);
                cnt++;

                foreach (var next in node.GetNexts())
                {
                    if (next is Indicator)
                    {
                        PrintTree(next as Indicator, dep + 1, order, ref cnt);
                    }
                }
            }
        }

        public static void PrintTree(this Indicator root)
        {
            Dictionary<Indicator, int> order = new Dictionary<Indicator, int>();
            var cnt = 0;
            PrintTree(root, 0, order, ref cnt);

            //            Range(0, depth).ForEach(i => Console.Write(" "));
            //            Console.WriteLine(root);
            //            root.GetNexts().ForEach(next =>
            //            {
            //                (next as Indicator)?.PrintTree(depth + 1);
            //            });
        }
    }
}