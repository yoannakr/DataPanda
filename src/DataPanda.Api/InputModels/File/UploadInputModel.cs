using Microsoft.AspNetCore.Http;

namespace DataPanda.Api.InputModels.File
{
    public class UploadInputModel : FileInputModel
    {
        public IFormFile FormFile { get; set; }
    }
}
