using System;
namespace QuantModel.DataProcessing
{
    public class Bar: IBar
    {
        public DateTime DateTime { get; set; }

        public Double Open { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public double Close { get; set; }

        public int Volume { get; set; }

        public int OpenInterest { get; set; }

        public Bar(DateTime dateTime, double open, double high, double low, double close, int volume, int openinterest)
        {
            DateTime = dateTime;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            OpenInterest = openinterest;
        }
        public Bar(){
            
        }

        public static Bar FromStringArray(string[] data) => new Bar
        {
            DateTime = DateTime.Parse(data[0]),
            Open = double.Parse(data[1]),
            High = double.Parse(data[2]),
            Low = double.Parse(data[3]),
            Close = double.Parse(data[4]),
            Volume = int.Parse(data[5]),
            OpenInterest = int.Parse(data[6])
        };
        public static Bar FormString(string dada) => FromStringArray(dada.Split(','));
    }
}
