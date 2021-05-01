namespace DataPanda.Application.Features.Files.Models
{
    public class StudentResult
    {
        public StudentResult(int id, double result)
        {
            Id = id;
            Result = result;
        }

        public int Id { get; set; }

        public double Result { get; set; }
    }
}
