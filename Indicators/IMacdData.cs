namespace QuantModel.Indicators
{
    public interface IMacdData
    {
        double Diff { get; }
        double Dea { get; }
        double Macd { get; }
    }
}