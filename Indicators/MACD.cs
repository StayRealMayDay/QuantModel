using System;
using System.Collections;
using System.Collections.Generic;
using QuantModel.Indicators.Generic;

namespace QuantModel.Indicators
{
    public class MACD: Indicator<IMacdData>
    {
        public MACD(IIndicator<double> source, int shortCycle, int longCycle, int difCycle)
        {
            Source = source;
            ShortCycle = shortCycle;
            LongCycle = longCycle;
            DifCycle = difCycle;
            var fast = Source.EMA(ShortCycle);
            var slow = Source.EMA(LongCycle);
            Dif = BinaryOperation.Create(fast, slow, (a, b) => a - b);
            Dea = Dif.EMA(difCycle);
            Macd = BinaryOperation.Create(Dif, Dea, (a, b) => 2 * (a - b));
            Dif.Update += Merge;
            Dea.Update += Merge;
            Macd.Update += Merge;
        }

        private void Merge()
        {
            Data.FillRange(Count, Macd.Count, i => new MacdData(){Diff = Dif[i], Dea = Dea[i], Macd = Macd[i]});
            FollowUp();
        }

        public BinaryOperation<double, double, double> Macd { get; }

        public EMA Dea { get; }

        public BinaryOperation<double, double, double> Dif { get; }

        private IIndicator<double> Source { get; }
        private int LongCycle { get; }
        private int ShortCycle { get; }
        private int DifCycle { get; }

        public override string ToString()
        {
            return $"{Source}.MACD({ShortCycle}, {LongCycle}, {DifCycle})";
        }
    }

  
}