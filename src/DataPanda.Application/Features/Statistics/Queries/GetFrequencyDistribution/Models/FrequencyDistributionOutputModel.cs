using System.Collections.Generic;

namespace DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models
{
    public class FrequencyDistributionOutputModel
    {
        public FrequencyDistributionOutputModel(IEnumerable<FrequencyDistribution> frequencyDistributions, int totalAbsoluteFrequency, double totalRelativeFrequency)
        {
            FrequencyDistributions = frequencyDistributions;
            TotalAbsoluteFrequency = totalAbsoluteFrequency;
            TotalRelativeFrequency = totalRelativeFrequency;
        }

        public IEnumerable<FrequencyDistribution> FrequencyDistributions { get; }

        public int TotalAbsoluteFrequency { get; }

        public double TotalRelativeFrequency { get; }
    }
}
