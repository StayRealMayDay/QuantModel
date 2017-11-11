using System;
using QuantModel.Indicators.Generic;
namespace QuantModel.Indicators
{
    public class ROI: Indicator<double>
    {
        public ROI(IIndicator<double> source)
        {
            Source = source;
            Source.Update += Source_Update;
        }

        void Source_Update()
        {
            Data.FillRange(Count, Source.Count, (arg) =>  arg == 0 ?  Source[0] : ((Source[arg] - Source[arg - 1])/ Source[arg - 1]));
            FollowUp();
        }

        public IIndicator<double> Source { get; }
    }
}
