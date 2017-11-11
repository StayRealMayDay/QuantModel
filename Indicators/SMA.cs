using System;
using System.Linq;
using static QuantModel.Extension;
using QuantModel.Indicators.Generic;
namespace QuantModel.Indicators
{
    /// <summary>
    /// Sma.
    /// </summary>
    public class SMA : Indicator<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuantModel.Indicators.SMA"/> class.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="cycle">Cycle.</param>
        public SMA(IIndicator<double> source, int cycle)
        {
            Source = source;
            Cycle = cycle;
            Source.Update += SourceOnUpdate;
        }
        /// <summary>
        /// Sources the on update.
        /// </summary>
        private void SourceOnUpdate()
        {
            Data.FillRange(Count, Source.Count, i => RangeRight(0, i + 1).Take(Cycle).Average(j => Source[j]));
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
        private int Cycle { get; }
       
        
    }
}