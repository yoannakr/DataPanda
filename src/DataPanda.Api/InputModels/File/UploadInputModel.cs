using Microsoft.AspNetCore.Http;

namespace DataPanda.Api.InputModels.File
{
    public class UploadInputModel
    {
        public IFormFile FormFile { get; set; }

        public string PlatformName { get; set; }

        public string PlatformType { get; set; }

        public string PlatformUrl { get; set; }

        public string CourseName { get; set; }

        public string CourseFieldOfApplication { get; set; }
    }
}
