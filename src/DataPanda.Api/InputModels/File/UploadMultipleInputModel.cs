using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DataPanda.Api.InputModels.File
{
    public class UploadMultipleInputModel : FileInputModel
    {
        public IEnumerable<IFormFile> FormFiles { get; set; }
    }
}
