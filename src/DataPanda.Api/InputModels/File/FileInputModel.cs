namespace DataPanda.Api.InputModels.File
{
    public abstract class FileInputModel
    {
        public string PlatformName { get; set; }

        public string PlatformType { get; set; }

        public string PlatformUrl { get; set; }

        public string CourseName { get; set; }

        public string CourseFieldOfApplication { get; set; }
    }
}
