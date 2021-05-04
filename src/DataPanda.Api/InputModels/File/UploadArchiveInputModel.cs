using Microsoft.AspNetCore.Http;

namespace DataPanda.Api.InputModels.File
{
    public class UploadArchiveInputModel : FileInputModel
    {
        public IFormFile FormFile { get; set; }
    }
}
