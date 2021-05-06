namespace DataPanda.Application.Features.Statistics.Queries.GetScatteringMeasures.Models
{
    public class ScatteringMeasuresOutputModel
    {
        public ScatteringMeasuresOutputModel(int swing, double dispersion, double standardDeviation)
        {
            Swing = swing;
            Dispersion = dispersion;
            StandardDeviation = standardDeviation;
        }

        public int Swing { get; }

        public double Dispersion { get; }

        public double StandardDeviation { get; }
    }
}
