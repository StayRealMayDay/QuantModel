using System;
using static System.Math;
using QuantModel.Indicators.Generic;
namespace QuantModel.Indicators
{
    public class HV: Indicator<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuantModel.Indicators.HV"/> class.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="cycle">Cycle.</param>
        public HV(IIndicator<double> source,int cycle)
        {
            Source = source;
            Cycle = cycle;
            var ROI = Source.ROI();
            Std = Source.StdDev(Cycle);
            Std.Update += Std_Update;
        }
        /// <summary>
        /// Stds the update.
        /// </summary>
        void Std_Update()
        {
            Data.FillRange(Count, Source.Count / Cycle,(arg) => Std[(arg + 1) * Cycle  - 1] * Sqrt(Cycle));
            FollowUp();
        }
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>The source.</value>
        public IIndicator<double> Source { get; }
        /// <summary>
        /// Gets the cycle.
        /// </summary>
        /// <value>The cycle.</value>
        public int Cycle { get; }
        /// <summary>
        /// Gets the std.
        /// </summary>
        /// <value>The std.</value>
        public IIndicator<double> Std { get; }


    }
}
