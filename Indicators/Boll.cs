using System;
using QuantModel.Indicators.Generic;
namespace QuantModel.Indicators
{
    public class Boll
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:QuantModel.Indicators.Boll"/> class.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="cycle">Cycle.</param>
        /// <param name="deviation">Deviation.</param>
        public Boll(IIndicator<double> source,int cycle, double deviation)
        {
            Source = source;
            Cycle = cycle;
            Deviation = deviation;
            Middle = Source.SMA(Cycle);
            Std = source.StdDev(cycle, Middle);
            Upper = BinaryOperation.Create(Middle, Std, (i, j) => i + j * Deviation);
            Lower = BinaryOperation.Create(Middle, Std, (i, j) => i - j * Deviation);
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
        /// Gets the middle.
        /// </summary>
        /// <value>The middle.</value>
        public IIndicator<double> Middle { get; }
         /// <summary>
         /// Gets the upper.
         /// </summary>
         /// <value>The upper.</value>
        public IIndicator<double> Upper { get; }
        /// <summary>
        /// Gets the lower.
        /// </summary>
        /// <value>The lower.</value>
        public IIndicator<double> Lower { get; }
        /// <summary>
        /// Gets the std.
        /// </summary>
        /// <value>The std.</value>
        public IIndicator<double> Std { get; }
        /// <summary>
        /// Gets the deviation.
        /// </summary>
        /// <value>The deviation.</value>
        public double Deviation { get; }
    }
}
