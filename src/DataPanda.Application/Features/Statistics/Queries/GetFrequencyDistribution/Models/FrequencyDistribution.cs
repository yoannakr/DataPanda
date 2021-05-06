namespace DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models
{
    public class FrequencyDistribution
    {
        public FrequencyDistribution(int numberOfSubmissions, int absoluteFrequency, double relativeFrequency)
        {
            NumberOfSubmissions = numberOfSubmissions;
            AbsoluteFrequency = absoluteFrequency;
            RelativeFrequency = relativeFrequency;
        }

        public int NumberOfSubmissions { get; }

        public int AbsoluteFrequency { get; }

        public double RelativeFrequency { get; }
    }
}
