using QuantModel.Indicators.Generic;
namespace QuantModel.Indicators
{
    public class EMA : Indicator<double>
    {
        public EMA(IIndicator<double> source, int cycle)
        {
            Source = source;
            Cycle = cycle;
            Source.Update += SourceOnUpdate;
        }

        private void SourceOnUpdate()
        {
//            for (var i = Count; i < Source.Count; i++)
//            {
//                if (i == 0)
//                {
//                    Data.Add(Source[i]);
//                }
//                else
//                {
//                    Data.Add((2.0 / (Cycle + 1)) * (Source[i] - Data[i - 1]) + Data[i - 1]);
//                }
//            }
            
            Data.FillRange(Count,Source.Count,i => i == 0 ? Source[0] : (2.0 / (Cycle + 1)) * (Source[i] - Data[i - 1]) + Data[i - 1]);
            
            FollowUp();
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>The source.</value>
        private IIndicator<double> Source { get; }
        /// <summary>
        /// Gets the cycle.
        /// </summary>
        /// <value>The cycle.</value>
        public int Cycle { get; }
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:QuantModel.Indicators.EMA"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:QuantModel.Indicators.EMA"/>.</returns>
        public override string ToString() => $"{Source}.EMA({Cycle})";
    }
}