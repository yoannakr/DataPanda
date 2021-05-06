namespace DataPanda.Application.Features.Statistics.Queries.GetCentralTrend.Models
{
    public class CentralTrendOutputModel
    {
        public CentralTrendOutputModel(int mode, int modeFrequency, double median, double average, double averageWithWeight)
        {
            Mode = mode;
            ModeFrequency = modeFrequency;
            Median = median;
            Average = average;
            AverageWithWeight = averageWithWeight;
        }

        public int Mode { get; }

        public int ModeFrequency { get; }

        public double Median { get; }

        public double Average { get; }

        public double AverageWithWeight { get; }
    }
}
