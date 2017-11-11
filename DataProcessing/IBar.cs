using System;
namespace QuantModel.DataProcessing
{
    public interface IBarHighLow
    {
        double High { get; }

        double Low { get; }
    }

    public interface IBarOpenClose
    {
        double Open { get; }
        double Close { get; }
    }

    public interface IBar: IBarHighLow, IBarOpenClose
    {
        DateTime DateTime { get; }

        int Volume { get; }

        int OpenInterest { get; }
    }
}
