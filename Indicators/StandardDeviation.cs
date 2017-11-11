using System;
using System.Linq;
using static System.Math;
using QuantModel.Indicators.Generic;
using static QuantModel.Extension;

namespace QuantModel.Indicators
{
    /// <summary>
    /// Standard deviation.
    /// </summary>
    public class StandardDeviation : Indicator<double>
    {   
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuantModel.Indicators.StandardDeviation"/> class.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="cycle">Cycle.</param>
        public StandardDeviation(IIndicator<double> source, int cycle)
        { 
            Source = source;
            Cycle = cycle;
            Average = new SMA(Source, Cycle);
            Source.Update += Source_Update;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuantModel.Indicators.StandardDeviation"/> class.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="average">Average.</param>
        /// <param name="cycle">Cycle.</param>
        public StandardDeviation(IIndicator<double> source, IIndicator<double> average, int cycle)
        {
            Source = source;
            Cycle = cycle;
            Average = average;
            Source.Update += Source_Update;
        }
        /// <summary>
        /// Sources the update.
        /// </summary>
        private void Source_Update()
        {
            Data.FillRange(Count, Source.Count, i => i > 1? Sqrt(RangeRight(0,i).Take(Cycle).Select(j => Source[j] - Average[i]).Select(m => m * m).Sum() / Min(Cycle - 1, i - 1)) : 0);
            FollowUp();
        }
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>The source.</value>
        public IIndicator<double> Source { get; }
        /// <summary>
        /// Gets the average.
        /// </summary>
        /// <value>The average.</value>
        public IIndicator<double> Average { get; } 
        /// <summary>
        /// Gets the cycle.
        /// </summary>
        /// <value>The cycle.</value>
        private int Cycle { get; }
    }
}
